/* Copyright (C) 2003 Atomic Blue (info@planeshift.it, http://www.atomicblue.org) (Original version)
 * Copyright (C) 2013 Stefano Angeleri (weltall2@gmail.com) (C# conversion and refactoring)
 * 
 * Author(s): Andrew Mann <amann tccgi.com>
 *            Stefano Angeleri <weltall2@gmail.com> (C# conversion and refactoring)
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation (version 2 of the License)
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace PSNameGenerator
{
    public class NameGenerator
    {
        #region Constants for flags

        /// <summary>
        /// Flag for the prejoiners.
        /// </summary>
        private const int PHONIC_PREJOINER = 0x01;

        /// <summary>
        /// Flag for the postjoiners.
        /// </summary>
        private const int PHONIC_POSTJOINER = 0x02;

        #endregion Constants for flags

        #region Parameters

        /// <summary>
        /// The total sum probability of all begin probabilities of phonics.
        /// </summary>
        private float beginTotal;

        /// <summary>
        /// The total sum probability of all end probabilities of phonics.
        /// </summary>
        private float endTotal;

        /// <summary>
        /// The total sum probability of all middle probabilities of prejoiner phonics.
        /// </summary>
        private float prejoinTotal;

        /// <summary>
        /// The total sum probability of all middle probabilities of not prejoiner phonics.
        /// </summary>
        private float nonprejoinTotal;

        /// <summary>
        /// A list of all phonic entries parsed for this generator.
        /// </summary>
        private List<PhonicEntry> entries;

        /// <summary>
        /// A random generator by this generator.
        /// </summary>
        private Random randomgen;

        #endregion Parameters

        /// <summary>
        /// Main constructor. Initializes this generator with the phonic 
        /// data used for it to generate names.
        /// </summary>
        /// <param name="containerNode">
        /// A <see cref="XmlNode"/> containing the phonic
        /// information for this generator.
        /// </param>
        public NameGenerator(XmlNode containerNode)
        {
            beginTotal = 0;
            endTotal = 0;
            prejoinTotal = 0;
            nonprejoinTotal = 0;

            XmlNodeList nodeList = containerNode.ChildNodes;
            entries = new List<PhonicEntry>();

            foreach (XmlNode node in nodeList)
            {
                // Gets each phonics and it's attributes.
                string phonic = node.Attributes.GetNamedItem("spelling").InnerText;
                double begin_probability = Double.Parse(node.Attributes.GetNamedItem("beginner").InnerText);
                double end_probability = Double.Parse(node.Attributes.GetNamedItem("ender").InnerText);
                double middle_probability = Double.Parse(node.Attributes.GetNamedItem("middle").InnerText);
                int flags = 0x0;

                if (node.Attributes.GetNamedItem("prejoiner").InnerText == "Y")
                {
                    flags |= PHONIC_PREJOINER;
                }

                if (node.Attributes.GetNamedItem("postjoiner").InnerText == "Y")
                {
                    flags |= PHONIC_POSTJOINER;
                }

                // Generate the new PhonicEntry with the parsed data.
                PhonicEntry entry = new PhonicEntry(phonic, (float)begin_probability, (float)end_probability, (float)middle_probability, flags);

                // Update global values for the generator.
                beginTotal += (float)begin_probability;
                endTotal += (float)end_probability;
                if ((flags & PHONIC_PREJOINER) > 0)
                {
                    prejoinTotal += (float)middle_probability;
                }
                else
                {
                    nonprejoinTotal += (float)middle_probability;
                }

                entries.Add(entry);
            }

            randomgen = new Random();
        }

        /// <summary>
        /// Generates a name priveded the lengthLow and
        /// lengthHigh values using the phonics provided by this generator.
        /// </summary>
        /// <param name="lengthLow">The lengthLow of the generated name.</param>
        /// <param name="lengthHigh">The lengthHigh of the generated name.</param>
        /// <returns></returns>
        public string GenerateName(int lengthLow, int lengthHigh)
        {
            PhonicEntry lastphonic = null;
            string namebuffer = string.Empty;

            // Determine the length.
            int length = randomgen.Next(lengthHigh - lengthLow) + lengthLow;

            // Pick a beginning.
            lastphonic = GetRandomBeginner();
            namebuffer += lastphonic.Phonic;

            // Add phonics to the middle while within length.
            while (namebuffer.Length < length)
            {
                if ((lastphonic.Flags & PHONIC_POSTJOINER) > 0)
                    lastphonic = GetRandomNonPreJoiner();
                else
                    lastphonic = GetRandomPreJoiner();
                namebuffer += lastphonic.Phonic;
            }

            // Pick an ending.
            lastphonic = GetRandomEnder(!((lastphonic.Flags & PHONIC_POSTJOINER) > 0));
            namebuffer += lastphonic.Phonic;

            return namebuffer.ToLower();
        }

        /// <summary>
        /// Gets a random Beginer for the name.
        /// </summary>
        /// <returns>A PhonicEntry to use as random beginner.</returns>
        private PhonicEntry GetRandomBeginner()
        {
            double randval = randomgen.NextDouble() * beginTotal;
            double currentsum = 0.0f;

            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].BeginProbability > 0.0f)
                {
                    currentsum += entries[i].BeginProbability;
                    if (randval < currentsum)
                        return (entries[i]);
                }
            }

            // We'll return the last one here, though this shouldn't happen, rounding error?
            return (entries[entries.Count - 1]);
        }

        /// <summary>
        /// Gets a random ender for the name.
        /// </summary>
        /// <param name="prejoiner">Whatever a prejoiner is requested or not.</param>
        /// <returns>A random Ender <see cref="PhonicEntry"/> of the requested type.</returns>
        private PhonicEntry GetRandomEnder(bool prejoiner)
        {
            Stopwatch timer = Stopwatch.StartNew();
            const long timeLimit = 5000;

            while (timer.ElapsedMilliseconds < timeLimit)
            {
                float randval = (float)randomgen.NextDouble() * endTotal;
                float currentsum = 0.0f;
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].EndProbability > 0.0f)
                    {
                        currentsum += entries[i].EndProbability;
                        if (randval < currentsum)
                        {
                            if ((((entries[i].Flags & PHONIC_PREJOINER) > 0) && prejoiner) ||
                                (!((entries[i].Flags & PHONIC_PREJOINER) > 0) && !prejoiner))
                            {
                                // Found the requested type.
                                return (entries[i]);
                            }
                            else
                            {
                                // Didn't find the requested type, reroll.
                                break;
                            }
                        }
                    }
                }
            }

            // We'll return the last one here, though this can't happen.
            return (entries[entries.Count - 1]);
        }

        /// <summary>
        /// Gets a random prejoiner.
        /// </summary>
        /// <returns>A <see cref="PhonicEntry"/> containing a random prejoiner.</returns>
        private PhonicEntry GetRandomPreJoiner()
        {
            float randval = (float)randomgen.NextDouble() * prejoinTotal;
            float currentsum = 0.0f;

            for (int i = 0; i < entries.Count; i++)
            {
                if (((entries[i].Flags & PHONIC_PREJOINER) > 0) && entries[i].MiddleProbability > 0)
                {
                    currentsum += entries[i].MiddleProbability;
                    if (randval < currentsum)
                        return (entries[i]);
                }
            }

            // We'll return the last one here, though this shouldn't happen, rounding error?
            return (entries[entries.Count - 1]);
        }

        /// <summary>
        /// Gets a random not prejoiner.
        /// </summary>
        /// <returns>A <see cref="PhonicEntry"/> containing a random not prejoiner.</returns>
        private PhonicEntry GetRandomNonPreJoiner()
        {
            float randval = (float)randomgen.NextDouble() * nonprejoinTotal;
            float currentsum = 0.0f;

            for (int i = 0; i < entries.Count; i++)
            {
                if (!((entries[i].Flags & PHONIC_PREJOINER) > 0) && entries[i].MiddleProbability > 0)
                {
                    currentsum += entries[i].MiddleProbability;
                    if (randval < currentsum)
                        return (entries[i]);
                }
            }

            // We'll return the last one here, though this shouldn't happen, rounding error?
            return (entries[entries.Count - 1]);
        }
    }
}
