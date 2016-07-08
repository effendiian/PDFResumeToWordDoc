#define DEBUG // Debug preprocessor.
// #undef DEBUG 
// TODO: Licensing boilerplate.

// Software being used:
// // CSVHelper - licensed under MS-PL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFToWordDoc
{
	// TODO: Program.cs description.
	public class Program
	{
	
		#region Debugging flags.

#if DEBUG
		public static bool DEBUG = true;
		public static int LINE = 0;
#else
		public static bool DEBUG = false;
		public static int LINE = -1;
#endif

		#endregion

		#region Commands and Dictionaries

		public static readonly Dictionary<string, string> COMMANDS
			= new Dictionary<string, string>()
			{
				{"yes", "CONFIRM"},
				{"yeah", "CONFIRM"},
				{"confirm", "CONFIRM"},
				{"positive", "CONFIRM"},
				{"okay", "CONFIRM"},
				{"agree", "CONFIRM"},
				{"true", "CONFIRM"},
				{"yep", "CONFIRM"},
				{"y", "CONFIRM"},
				{"no", "DECLINE"},
				{"nope", "DECLINE"},
				{"disagree", "DECLINE"},
				{"negative", "DECLINE"},
				{"cancel", "DECLINE"},
				{"incorrect", "DECLINE"},
				{"false", "DECLINE"},
				{"nah", "DECLINE"},
				{"n", "DECLINE"},
				{"quit", "EXIT"},
				{"close", "EXIT"},
				{"exit", "EXIT"},
				{"depart", "EXIT"},
				{"leave", "EXIT"},
				{"ext", "EXIT"},
				{"q", "EXIT"},
				{"alt+f4", "EXIT"},
				{"alt f4", "EXIT"},
				{"escape", "EXIT"},
				{"esc", "EXIT"},
				{"shutdown", "EXIT"}
			};

		public const string CONFIRM = "cmd::accept";
		public const string DECLINE = "cmd::cancel";
		public const string EXIT = "cmd::exit";
		public static readonly string[] COMMANDKEYS = new string[]
		{
			"yes",
			"yeah",
			"confirm",
			"positive",
			"okay",
			"agree",
			"true",
			"yep",
			"y",
			"no",
			"nope",
			"disagree",
			"negative",
			"cancel",
			"incorrect",
			"false",
			"nah",
			"n",
			"quit",
			"close",
			"exit",
			"depart",
			"leave",
			"ext",
			"q",
			"alt+f4",
			"alt f4",
			"escape",
			"esc",
			"shutdown"
		};

		public static readonly string[] CONFIRMATION = new string[]
		{
			"yes",
			"yeah",
			"confirm",
			"positive",
			"okay",
			"agree",
			"true",
			"yep",
			"y"
		};

		public static readonly string[] DECLINATION = new string[]
		{
			"no",
			"nope",
			"disagree",
			"negative",
			"cancel",
			"incorrect",
			"false",
			"nah",
			"n"
		};

		public static readonly string[] CLOSE = new string[]
		{
			"quit",
			"close",
			"exit",
			"depart",
			"leave",
			"ext",
			"q",
			"alt+f4",
			"alt f4",
			"escape",
			"esc",
			"shutdown"
		};

		public static readonly Dictionary<char, char> toLowercase
			= new Dictionary<char, char>()
			{
				{'A','a'},
				{'B','b'},
				{'C','c'},
				{'D','d'},
				{'E','e'},
				{'F','f'},
				{'G','g'},
				{'H','h'},
				{'I','i'},
				{'J','j'},
				{'K','k'},
				{'L','l'},
				{'M','m'},
				{'N','n'},
				{'O','o'},
				{'P','p'},
				{'Q','q'},
				{'R','r'},
				{'S','s'},
				{'T','t'},
				{'U','u'},
				{'V','v'},
				{'W','w'},
				{'X','x'},
				{'Y','y'},
				{'Z','z'},
			};

		public static readonly Dictionary<char, char> toUppercase 
			= new Dictionary<char, char>()
			{
				{'a','A'},
				{'b','B'},
				{'c','C'},
				{'d','D'},
				{'e','E'},
				{'f','F'},
				{'g','G'},
				{'h','H'},
				{'i','I'},
				{'j','J'},
				{'k','K'},
				{'l','L'},
				{'m','M'},
				{'n','N'},
				{'o','O'},
				{'p','P'},
				{'q','Q'},
				{'r','R'},
				{'s','S'},
				{'t','T'},
				{'u','U'},
				{'v','V'},
				{'w','W'},
				{'x','X'},
				{'y','Y'},
				{'z','Z'}
			};

		#endregion

		// TODO: Header.
		public static void Main(string[] args)
		{
			// Main program:
			// Process 1:
			// PDF document is read.
			// // If PDF can't be read, notify user of the issue. If the file is open in another program, for example.
			// // If PDF CAN be read, it takes all the text out of it and stores it in memory, passing it along to the next process.

			// Exported text is parsed. // This will change depending on whether we use third-party software or use the in-house methods from before.
			// // All available text is read out of it.
			// // Information is pushed into a CSV file.

			// CSV Storage is configured. // This sets up a csv file in a particular way so that it can be saved.
			// // Asks user to count how many experiences and education histories are being read.
			// // Asks user if there will be extra information that isn't usually read, to be parsed and added to the .CSV
			
			// CSV Storage validates all information:
			// // Incorrect/invalid information is given a warning flag in the CSV.
			// // Missing information is flagged as needing input into the CSV.
			// // CSV file is saved as lastname_firstname_resume.csv

			// Process 2:
			// Opens up the CSV file and checks for the warning and missing information flags.
			// // If missing or invalid, asks user to fill in the empty / problematic information.
			// // Storage then overwrites the initial CSV file with the modified file, and tests validation again.

			// Validated CSV file is sent to the third piece of the puzzle: the "to Word Doc" portion.
			// // Asks user if they want .doc or .docx conversion.
			// // Checks to see if the proper files are installed on the computer, if necessary. (If not, the csv file can at least be copied to another computer in order to complete the job).

			// CSV has the information already sorted and portioned in the proper areas:
			// // Goes through CSV, with assumption the order is correct.
			// // Assume information in CSV is already converted; we don't need to change "Jan 2016" into "1/2016" - we assume it's been done already by this point in the operation.
			// // Take the information and dump them into the correct spots. Tables, horizontal lines, and more are all created in their designated positions.
			// // Save the file as .doc or .docx depending on what is necessary.
			
			// // We don't need to flag the word document to check for information because it's already been done by the CSV.

			// // In the future, should a different file format be necessary, modules can be developed to export to new formats or import from new formats.
			
			// // The pipeline is made up by:  Importer -> CSV Configuration -> Exporter
			// // Each piece should have a portion designated by the UI for interaction with.
		}

		#region Tests

		// TODO: Implement test for loading PDF.

		// TODO: Implement test for reading text from PDF.

		// TODO: Implement test for printing PDF information.

		// TODO: Implement test for file-lock testing of PDF.

		// TODO: Implement user-notification test.

		// TODO: Implement parsing test.

		// TODO: Implement phone number validation test.

		// TODO: Implement CSV configurable creation test.

		// TODO: Implement CSV reading test of various CSV files.

		// TODO: Implement warning flag system.

		// TODO: Implement missing flag system.

		// TODO: Implement email validation test.

		// TODO: Implement date validation test.

		// TODO: Implement address validation test.

		// TODO: Implement file-saving mechanism for .csv files.

		// TODO: Implement CSV correction mechanism and test for it.

		// TODO: Implement "optional" portion for CSV corrections.

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 
		
		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 

		// TODO: 


		#endregion

		#region Printer functions.

		public void debug(string msg)
		{
			if (DEBUG) { print("" + LINE + ": " + msg); ++LINE; }
		}

		public void debugf(string msg)
		{
			if (DEBUG) { printf("" + LINE + ": " + msg); ++LINE; }
		}

		public void debugp(string msg)
		{
			if (DEBUG) { pause("" + LINE + ": " + msg); ++LINE; }
		}

		public void debugpf(string msg)
		{
			if (DEBUG) { pausef("" + LINE + ": " + msg); ++LINE; } 
		}

		public void error(string msg)
		{
			debugp("Error: " + msg);
		}

		public void error(Exception e)
		{
			debugp("Error: " + e.Message);
			debugp("Error: " + e.Source);
			debugp("Error: " + e.StackTrace);
		}

		public void error(string msg, Exception e)
		{
			error(msg);
			error(e);
		}

		public void print()
		{
			print("");
		}

		public void print(string msg, bool newline)
		{
			if (newline)
			{
				Console.WriteLine(msg);
			}
			else
			{
				Console.Write(msg);
			}
		}

		public void print(string msg)
		{
			print(msg, true);
		}

		public void printf(string msg)
		{
			print(msg, false);
		}

		public void pause()
		{
			printf("Press any key to continue...");
			Console.ReadKey(true);
			print();
		}

		public void pause(string msg)
		{
			print(msg);
			pause();
		}

		public void pausef(string msg)
		{
			printf(msg);
			pause();
		}

		// Will either close or return false
		public bool close()
		{
			int key = read("Would you like to exit the program? y/n", COMMANDKEYS);

			if (key == -1 || CLOSE.Contains(COMMANDKEYS[key]) || DECLINATION.Contains(COMMANDKEYS[key]))
			{
				return false;
			}

			if (CONFIRMATION.Contains(COMMANDKEYS[key]))
			{
				pause("The program will now close.");
				System.Environment.Exit(System.Environment.ExitCode);
				return true;
			}

			return false;
		}

		// Returns true for yes.
		// Returns false for no.
		// Returns false for failure.
		public bool processCommand(string key)
		{
			if (COMMANDS.ContainsKey(key))
			{
				string cmd = COMMANDS[key];
				debug("key: " + key + " --> " + cmd);
				switch (cmd)
				{
					case CONFIRM:
						return true;
					case DECLINE:
						return false;
					case EXIT:
						return close();
					default:
						debug("There was an error.");
						return false;
				}
			}
			else
			{
				return false; // If it cannot be read, return false.
			}
		}

		public bool validread(string query, out int answer, params string[] keys)
		{
			int min = 0;
			int max = keys.Length;
			answer = read(query, keys);

			return (answer == -1 || InRange(min, max, answer, true, false));
		}

		public bool validreadkey(string query, out int answer, params char[] keys)
		{
			int min = 0;
			int max = keys.Length;
			answer = readKey(query, keys);

			return (answer == -1 || InRange(min, max, answer, true, false));
		}

		// Returns the index of the matching key.
		// Returns -1 if no match.
		public int read(string query, params string[] key)
		{
			print(query);
			string input = Console.ReadLine();
			input = input.Trim();
			
			if (key.Length > 0 && !String.IsNullOrEmpty(input))
			{
				for (int index = 0; index < key.Length; index++)
				{
					// Check if input is a match with current msg[index].
					if(input.ToLower() == key[index].ToLower())
					{
						return index;
					}
				}
			}
			
			return -1;
		}

		public int readKey(string query, params char[] key)
		{
			print(query);
			char input = Console.ReadKey(false).KeyChar;			
			if (key.Length > 0 && IsValidCharacter(input))
			{
				for (int index = 0; index < key.Length; index++)
				{
					// Check if input is a match with current msg[index].
					if (ToLower(input) == ToLower(key[index]))
					{
						return index;
					}
				}
			}

			return -1;
		}

		public char ToLower(char c)
		{
			if (toLowercase.ContainsKey(c))
			{
				return toLowercase[c];
			}
			else
			{
				return c;
			}
		}

		public char ToUpper(char c)
		{
			if (toUppercase.ContainsKey(c))
			{
				return toUppercase[c];
			}
			else
			{
				return c;
			}
		}

		public bool IsValidCharacter(char c)
		{
			int keyNum = (int)c;
			int zeroNum = 48;
			int nineNum = 57;
			int a = 97;
			int z = a + 25;
			int A = 65;
			int Z = A + 25;


			if (InRange(zeroNum, nineNum, keyNum) 
				|| InRange(a, z, keyNum)
				|| InRange(A, Z, keyNum))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool InRange(int min, int max, int test)
		{
			return InRange(min, max, test, true, true);
		}

		public bool InRange(int min, int max, int test, bool inclusiveStart, bool inclusiveEnd)
		{
			int start = min;
			int end = max;

			if (!inclusiveStart)
			{
				start += 1;
			}
			

			if (!inclusiveEnd)
			{
				end -= 1;
			}

			if(end < start || start > end) { return false; } // Invalid range.
			else if (start == test || test == end) { return true; }
			else if (start <= test && test <= end) { return true; }
			else { return false; } // If not in range.
		}

#endregion
	}
}
