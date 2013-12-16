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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PSNameGenerator
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                // Run the GUI version.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GUIProgram());
            }
            else if (args.Contains("-h") || args.Contains("/h") || args.Contains("/?"))
            {
                // help requested. Just print it out.
                Version version = Assembly.GetEntryAssembly().GetName().Version;
                AssemblyName name = Assembly.GetEntryAssembly().GetName();
                Console.WriteLine("PS Name Generator v." + version.Major + "." + version.Minor + "." + version.Revision);
                Console.WriteLine();
                Console.WriteLine(name.Name + " [args group 1] [args group 2]...");
                Console.WriteLine("With no arguments a gui will be opened.");
                Console.WriteLine("-h /h /? show this help. Any other argument will be ignored.");
                Console.WriteLine("-d [path] The database to load for the name generator, defaults to integrated database.");
                Console.WriteLine("An args group is formed by one of these:");
                Console.WriteLine("-m Generate male names.");
                Console.WriteLine("-f Generate female names.");
                Console.WriteLine("-s Generate family names.");
                Console.WriteLine("The modifiers -m -f -s will be parsed one by one and the arguments");
                Console.WriteLine("between each modifier will change the generation options");
                Console.WriteLine("for that specific entry.");
                Console.WriteLine("This allows to generate names in the whished form and");
                Console.WriteLine("the amount of names which is wanted.");
                Console.WriteLine();
                Console.WriteLine("Each modifier takes these arguments:");
                Console.WriteLine("-c [num] The amount of names to generate for this modifier,");
                Console.WriteLine("         if higher than one each name will be separated by a comma.");
                Console.WriteLine("-l [num 1] [num 2] The minimum (num 1) and maximum (num 2)");
                Console.WriteLine("                   length of the generated names.");
                Console.WriteLine("Note -c defaults to 1 and -l to these:");
                Console.WriteLine("Male names: 4 - 7");
                Console.WriteLine("Female names: 5 - 5");
                Console.WriteLine("Family names: 4 - 7");
                Console.WriteLine();
                Console.WriteLine("Examples:");
                Console.WriteLine();
                Console.WriteLine(name + " -m");
                Console.WriteLine("Generates one male name using default settings.");
                Console.WriteLine();
                Console.WriteLine(name.Name + " -m -c 100 -l 5 10");
                Console.WriteLine("Generates 100 male name of length 5 to 10 characters.");
                Console.WriteLine();
                Console.WriteLine(name.Name + " -m -s");
                Console.WriteLine("Generates a male name and a family name.");
                Console.WriteLine();
                Console.WriteLine(name.Name + " -m -c 100 -l 5 10 -f -c 100 -l 8 12 -s -c 200 -l 3 10 -m -c 100");
                Console.WriteLine("Generates 100 male names of length 5 to 10, then 100 female names of");
                Console.WriteLine("length 8 to 12, then 200 family names of length 3 to 10 and finally");
                Console.WriteLine("100 male names with default settings.");
            }
            else
            {
                // Command line handling.
                // Prepare an instance of the name generation system.
                NameGenerationSystem system = new NameGenerationSystem();

                // Temporary status of the system.
                List<WorkSet> workSets = new List<WorkSet>();
                WorkSet currentWorkSet = null;
                string databasePath = null;

                // Lamba function to handle in a single line repeated code for
                // the various types of generators.
                Action<GeneratorTypes> SetNewWorkSet = (type) => 
                    {
                        if(currentWorkSet != null)
                        {
                            workSets.Add(currentWorkSet);
                        }

                        currentWorkSet = new WorkSet(type);
                    };

                // Scan all elements of the command line and handle the output.
                for(int i = 0; i < args.Length; ++i)
                {
                    string value = args[i];
                    if (value == "-m")
                    {
                        SetNewWorkSet(GeneratorTypes.NAMEGENERATOR_MALE_FIRST_NAME);
                    }
                    else if (value == "-f")
                    {
                        SetNewWorkSet(GeneratorTypes.NAMEGENERATOR_FEMALE_FIRST_NAME);
                    }
                    else if (value == "-s")
                    {
                        SetNewWorkSet(GeneratorTypes.NAMEGENERATOR_FAMILY_NAME);
                    }
                    else if (value == "-d" && (i + 1 < args.Length))
                    {
                        // Gets a database path, if requested.
                        databasePath = args[i + 1];
                        ++i;
                    }
                    else if (currentWorkSet != null)
                    {
                        // These can be used only when the current work set isn't null.
                        if (value == "-c" && (i + 1 < args.Length))
                        {
                            // Parses a count parameter. It wants one integer parameter.
                            try
                            {
                                currentWorkSet.Count = int.Parse(args[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                                Console.WriteLine("Unable to parse number: " + args[i + 1]);
                                return 1;
                            }
                        }
                        else if (value == "-l" && (i + 2 < args.Length))
                        {
                            // Parses a length parameter. It wants two integer parameters.
                            try
                            {
                                currentWorkSet.Min = int.Parse(args[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                                Console.WriteLine("Unable to parse number: " + args[i + 1]);
                                return 1;
                            }

                            try
                            {
                                currentWorkSet.Max = int.Parse(args[i + 2], System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                                Console.WriteLine("Unable to parse number: " + args[i + 2]);
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        // The parameter wasn't recognised or was in the wrong position.
                        // Bail out with an error.
                        Console.Write("invalid argument(s) found (did you forget to put an -m -f -s or used an invalid argument?) at this point:");
                        for (; i < args.Length; ++i)
                        {
                            Console.Write(" " + args[i]);
                        }

                        Console.WriteLine(".");
                        return 1;
                    }
                }

                // Push the last workset
                workSets.Add(currentWorkSet);

                // Load the database.
                try
                {
                    if (databasePath != null)
                    {
                        system.LoadDatabase(databasePath);
                    }
                    else
                    {
                        Stream databaseStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PSNameGenerator.phonics.xml");
                        system.LoadDatabase(databaseStream);
                    }
                }
                catch (Exception e)
                {
                    // Parsing or extraction error on the database, notify the user and exit.
                    Console.WriteLine("Unable to parse the database: " + e.Message);
                    return 1;
                }

                // Now execute the work sets.
                foreach (WorkSet work in workSets)
                {
                    for (int i = 0; i < work.Count; i++)
                    {
                        Console.WriteLine(system.GenerateName(work.GeneratorTypeNum, work.Min, work.Max));
                    }
                }
            }

            // Remove for normal command line operation. Used for debug from IDE.
            //Console.ReadLine();
            return 0;
        }
    }
}
