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

namespace PSNameGenerator
{
    /// <summary>
    /// Represent a single workset.
    /// </summary>
    public class WorkSet
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the type of generation to do.
        /// </summary>
        public GeneratorTypes GeneratorType { get; set; }

        /// <summary>
        /// Gets the int value, regarding the position in the enum,
        /// of the current generation type.
        /// </summary>
        public int GeneratorTypeNum
        {
            get
            {
                return (int)GeneratorType;
            }
        }

        /// <summary>
        /// Gets or sets the amount of names to generate for this workset.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the minimum size of names to generate for this workset.
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of names to generate for this workset.
        /// </summary>
        public int Max { get; set; }

        #endregion Parameters

        #region Constructors

        /// <summary>
        /// Initializes a new workSet with the default parameters
        /// for the specific generator type used.
        /// </summary>
        /// <param name="type">The type of generator to use <see cref="GeneratorTypes"/>.</param>
        public WorkSet(GeneratorTypes type)
        {
            Count = 1;

            if (type == GeneratorTypes.NAMEGENERATOR_MALE_FIRST_NAME)
            {
                Min = 4;
                Max = 7;
            }
            else if (type == GeneratorTypes.NAMEGENERATOR_FEMALE_FIRST_NAME)
            {
                Min = 5;
                Max = 5;
            }
            else if (type == GeneratorTypes.NAMEGENERATOR_FAMILY_NAME)
            {
                Min = 4;
                Max = 7;
            }
        }

        #endregion Constructors
    }
}
