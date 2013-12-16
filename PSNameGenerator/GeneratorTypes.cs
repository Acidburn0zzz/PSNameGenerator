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
    /// The possible types of generators.
    /// </summary>
    public enum GeneratorTypes
    {
        /// <summary>
        /// Identifies a female name generator.
        /// </summary>
        NAMEGENERATOR_FEMALE_FIRST_NAME = 0,

        /// <summary>
        /// Identifies a male name generator.
        /// </summary>
        NAMEGENERATOR_MALE_FIRST_NAME,

        /// <summary>
        /// Identifies a family name generator.
        /// </summary>
        NAMEGENERATOR_FAMILY_NAME,

        /// <summary>
        /// Identifies the end of types.
        /// </summary>
        NAMEGENERATOR_MAX
    }
}
