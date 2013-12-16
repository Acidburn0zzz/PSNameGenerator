/* Copyright (C) 2013 Stefano Angeleri (weltall2@gmail.com) 
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are
 * met:
 * 
 *  (1) Redistributions of source code must retain the above copyright
 *  notice, this list of conditions and the following disclaimer. 
 *  
 * (2) Redistributions in binary form must reproduce the above copyright
 * notice, this list of conditions and the following disclaimer in
 * the documentation and/or other materials provided with the
 * distribution.  
 * 
 * (3)The name of the author may not be used to
 * endorse or promote products derived from this software without
 * specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING
 * IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PSNameGenerator
{
    /// <summary>
    /// The GUI version of the generator: main form.
    /// </summary>
    public partial class GUIProgram : Form
    {
        /// <summary>
        /// Utility function to initialize the components on the form.
        /// </summary>
        public GUIProgram()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Generates names with the provided parameters in the form.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            GeneratorTypes selectedType;

            // Prepare an instance of the name generation system.
            NameGenerationSystem system = new NameGenerationSystem();

            // Check which checkbox was choosen for the generator
            if (this.radioButtonTypeMale.Checked)
            {
                selectedType = GeneratorTypes.NAMEGENERATOR_MALE_FIRST_NAME;
            }
            else if (this.radioButtonTypeFemale.Checked)
            {
                selectedType = GeneratorTypes.NAMEGENERATOR_FEMALE_FIRST_NAME;
            }
            else
            {
                selectedType = GeneratorTypes.NAMEGENERATOR_FAMILY_NAME;
            }

            // Initialize the WorkSet with default values.
            WorkSet work = new WorkSet(selectedType);

            // Gather parameter values.
            int count = (int)this.numericUpDownCountMax.Value;
            int lengthMax = (int)this.numericUpDownLengthMax.Value;
            int lengthMin = (int)this.numericUpDownLengthMin.Value;

            // Apply them if they are different than 0 (default).
            if (count > 0)
            {
                work.Count = count;
            }

            if (lengthMax > 0)
            {
                work.Max = lengthMax;
            }

            if (lengthMin > 0)
            {
                work.Min = lengthMin;
            }

            // Check if the required lengths are sane.
            if (work.Min > work.Max)
            {
                // Check the error condition and notify the user, if it's not caused by a default.

                // CHECK 1: one of the values was a default.
                if (lengthMin == 0 || lengthMax == 0)
                {
                    // In this case make max = min.
                    work.Min = work.Max;
                }
                else
                {
                    // CHECK 2: the user input wrong value. Notify the user and abort.
                    MessageBox.Show("The maximum lenght is lower than the minimum length. Please check again the desidered length values.");
                    return;
                }
            }

            // Load the embedded database.
            Stream databaseStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PSNameGenerator.phonics.xml");
            system.LoadDatabase(databaseStream);

            string output = string.Empty;

            // Now start the job.
            for (int i = 0; i < work.Count; i++)
            {
                output += system.GenerateName(work.GeneratorTypeNum, work.Min, work.Max) + Environment.NewLine;
            }

            // Set the output text to the form for display.
            this.textBoxOutput.Text = output;
        }
    }
}
