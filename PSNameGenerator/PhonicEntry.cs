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

namespace PSNameGenerator
{
    /// <summary>
    /// Identifies a possible phonic usable by the generator.
    /// </summary>
    public class PhonicEntry
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the phonic string of this entry.
        /// </summary>
        public string Phonic { get; set; }

        /// <summary>
        /// Gets or sets the probability of being at the beginning of a name.
        /// </summary>
        public float BeginProbability { get; set; }

        /// <summary>
        /// Gets or sets the probability of being at the end of a name.
        /// </summary>
        public float EndProbability { get; set; }

        /// <summary>
        /// Gets or sets the probability of being at the middle of a name.
        /// </summary>
        public float MiddleProbability { get; set; }

        /// <summary>
        /// Gets or sets Particular flags for this phonic.
        /// </summary>
        public int Flags { get; set; }

        #endregion Parameters

        #region Constructors

        /// <summary>
        /// Basic constructor just, just initializes empty values.
        /// </summary>
        public PhonicEntry()
        {
            Phonic = string.Empty;
            BeginProbability = EndProbability = MiddleProbability = 0.0f;
            Flags = 0x00;
        }

        /// <summary>
        /// Initializes an instance with all parameters set.
        /// </summary>
        /// <param name="phonic"></param>
        /// <param name="beginProbability"></param>
        /// <param name="endProbability"></param>
        /// <param name="middleProbability"></param>
        /// <param name="flags"></param>
        public PhonicEntry(string phonic, float beginProbability, float endProbability, float middleProbability, int flags)
        {
            Phonic = phonic;
            BeginProbability = beginProbability;
            EndProbability = endProbability;
            MiddleProbability = middleProbability;
            Flags = flags;
        }

        #endregion Constructors
    }
}
