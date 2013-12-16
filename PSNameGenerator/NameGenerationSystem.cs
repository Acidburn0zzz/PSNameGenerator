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
using System.Xml;

namespace PSNameGenerator
{
    /// <summary>
    /// Name generation System.
    /// This class and the other (GeneratorTypes, NameGenerator, PhonicEntry)
    /// allow for generation of random names.
    /// 
    /// The current implementation uses a table of phonetic spellings
    /// for the english language.
    /// 
    /// Usage:
    /// Create a new NameGenerationSystem() and load a database with
    /// the LoadDatabase() functions.
    /// Call NameGenerationSystem.GenerateName(type, lengthLow, lengthMax).
    /// The return value will be a string with the requested generated name.
    /// The type should be one of the <see cref="GeneratorTypes" /> excluding
    /// NAMEGENERATOR_MAX converted to an int with (int).
    /// 
    /// lengthLow and lengthMax are not hard maximums. Rather, a random number
    /// is picked between low and high. As name generation progresses, if
    /// the length of the name exceeds this number, and ending sequence is added.
    /// The resulting string will be 1-9 characters longer than the number picked.
    /// 
    /// Some rough guidelines and notes:
    /// Male names seem to come out much better when shorter. Try lengthLow = 3
    /// and lengthMax = 5 for male first names.
    /// Female names seem to work well with lengthLow = 7 lengthMax = 7.
    /// Surnames (family names) work ok with 8, 10.
    /// 
    /// The values above were originally in the comments of the original implementation,
    /// but the code using it ended up using for male 4 - 7,
    /// for female 5 - 5 and for surnames 4 - 7.
    /// These new defaults have been used then.
    /// 
    /// This implementation works by classifying phonetic bits according to 5 properties:
    /// * Likelyness to begin a name
    /// * Likelyness to end a name
    /// * Likelyness to appear in the middle of a name
    /// * Begins in a vowel
    /// * Ends in a vowel
    /// 
    /// The last two properties are not strictly tied to vowels,
    /// but generally follow that pattern. They help the name generator
    /// decide which sequences can appear next to each other without
    /// resulting in unpronouncable names.
    /// 
    /// The first three values are determined by running a list of a
    /// particular type of name (male first names for example) through a
    /// filter that searches for occurances of each phonetic bit
    /// and adjusts the weight accordingly.
    /// </summary>
    class NameGenerationSystem
    {
        #region Parameters

        /// <summary>
        /// The generators for names.
        /// </summary>
        private NameGenerator[] generators;

        #endregion Parameters

        #region Constructors

        /// <summary>
        /// Base constructor. Just initializes empty name generators.
        /// </summary>
        public NameGenerationSystem()
        {
            generators = new NameGenerator[(int)GeneratorTypes.NAMEGENERATOR_MAX];
        }

        #endregion Constructors.

        #region Phonic DB Loading Methods

        /// <summary>
        /// Load all name rules into memory for future use from file.
        /// </summary>
        /// <param name="dbPath">The file system path to load the database from.</param>
        /// <exception cref="Exception">Might return exceptions from the xml parser.</exception>
        public void LoadDatabase(string dbPath)
        {
            XmlDocument db = new XmlDocument();
            db.Load(dbPath);
            LoadDatabase(db);
        }

        /// <summary>
        /// Load all name rules into memory for future use from stream.
        /// </summary>
        /// <param name="dbStream">The stream to load the database from.</param>
        /// <exception cref="Exception">Might return exceptions from the xml parser.</exception>
        public void LoadDatabase(System.IO.Stream dbStream)
        {
            XmlDocument db = new XmlDocument();
            db.Load(dbStream);
            LoadDatabase(db);
        }

        /// <summary>
        /// Load all name rules into memory for future use from XmlDocument.
        /// </summary>
        /// <param name="db">The <see cref="XmlDocument"/> to load the database from.</param>
        /// <exception cref="Exception">Might return exceptions from the xml parser.</exception>
        public void LoadDatabase(XmlDocument db)
        {
            XmlNode nodeFamily = db.DocumentElement.SelectSingleNode("/generators/FAMILY_NAME");
            XmlNode nodeFemale = db.DocumentElement.SelectSingleNode("/generators/FEMALE_FIRST_NAME");
            XmlNode nodeMale = db.DocumentElement.SelectSingleNode("/generators/MALE_FIRST_NAME");

            // Now pass the node to each generator.
            generators[0] = new NameGenerator(nodeFemale);
            generators[1] = new NameGenerator(nodeMale);
            generators[2] = new NameGenerator(nodeFamily);
        }

        #endregion Phonic DB Loading Methods

        #region Generation Methods

        /// <summary>
        /// Generate a name of the requested type, fill it into namebuffer.
        /// </summary>
        /// <param name="generatorType">The type of generator to use 0 => female, 1 => male, 2 => family.</param>
        /// <param name="lengthLow">The minimum length of names.</param>
        /// <param name="lengthHigh">The maximum length of names.</param>
        /// <returns></returns>
        public string GenerateName(int generatorType, int lengthLow, int lengthHigh)
        {
            // Generate a string only if valid parameters are passed.
            if (generatorType >= 0 && generatorType < (int)GeneratorTypes.NAMEGENERATOR_MAX && generators[generatorType] != null)
                return generators[generatorType].GenerateName(lengthLow, lengthHigh);

            return string.Empty;
        }

        #endregion Generation Methods
    }
}
