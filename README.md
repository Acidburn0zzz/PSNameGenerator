PSNameGenerator
===============

A Name Generator based on PS.

The generator provides a standalone version of the PlaneShift name generator.
It was converted to c#, cleaned up, commented and refactored. Additionally
a GUI and a CLI access was provided.

The generator originally is able to generate male, female and surnames based
on a phonics.xml file, which is provided and embedded when built.
The generators contains some default choices which are the same used in PlaneShift,
but can be costumized to generate names of any length (provided the time), and
can automatically generate a choosen number of names with a single command.

The application requires .net 4.0 so it requires these dependencies:
* .net framework 4.0 on windows
* mono >= 2.10 on linux/macOSX

And doesn't use any external library than what's provided by the framework.

The application will run in two modes: CLI and GUI.
If nothing is passed as argument the application will automatically start
in GUI mode providing easy access through a classic windows.form interface,
which will work on all operating systems able to run mono.

If command arguments are passed the application will work in CLI mode supporting
all the arguments and various types of generations to be done in sequence.

PSNameGenerator [args group 1] [args group 2]...
With no arguments a gui will be opened.
-h /h /? show this help. Any other argument will be ignored.
-d [path] The database to load for the name generator, defaults to integrated database.

An args group is formed by one of these:
-m Generate male names.
-f Generate female names.
-s Generate family names.

The modifiers -m -f -s will be parsed one by one and the arguments 
between each modifier will change the generation options for that 
specific entry.
This allows to generate names in the whished form and
the amount of names which is wanted.

Each modifier takes these arguments:
-c [num] The amount of names to generate for this modifier,
         if higher than one each name will be separated by a comma.
-l [num 1] [num 2] The minimum (num 1) and maximum (num 2)
                   length of the generated names.");
Note -c defaults to 1 and -l to these:
Male names: 4 - 7
Female names: 5 - 5
Family names: 4 - 7;

Examples:
PSNameGenerator -m
Generates one male name using default settings.

PSNameGenerator -m -c 100 -l 5 10");
Generates 100 male name of length 5 to 10 characters.

PSNameGenerator -m -s
Generates a male name and a family name.

PSNameGenerator -m -c 100 -l 5 10 -f -c 100 -l 8 12 -s -c 200 -l 3 10 -m -c 100
Generates 100 male names of length 5 to 10, then 100 female names of
length 8 to 12, then 200 family names of length 3 to 10 and finally
100 male names with default settings.");
