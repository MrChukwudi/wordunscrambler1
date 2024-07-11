using System.IO;

namespace WordUnscrambler
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool tryAgain = true;

			while (tryAgain)
			{
				UnscrambleOperation unscrambleOperation = new UnscrambleOperation();


				List<string> scrambledFile;
				List<string> unScrambledFile;
				List<string> resultString;
				string scrambleFilePath;
				string unScrambleFilePath;

				Console.WriteLine("To select a choice, Chose between File or Manual");
				string option = Console.ReadLine();

				if (option == "File") //User choses to read from File
				{
					scrambleFilePath = Console.ReadLine();
					Console.WriteLine("Enter File Path:");
					scrambledFile = unscrambleOperation.ReadFile(scrambleFilePath);
				}
				else
				{
					scrambledFile = unscrambleOperation.ReadInput();
				}

				Console.WriteLine("Enter Unscramble File Path here:");
				unScrambleFilePath = Console.ReadLine();
				unScrambledFile = unscrambleOperation.ReadFile(unScrambleFilePath);

				resultString = unscrambleOperation.UnscrambleWords(scrambledFile, unScrambledFile);


				string formattedString = string.Join("\n\n", resultString);
                Console.WriteLine(formattedString);

                Console.WriteLine("Do you want to try again");
				string myTryAgain = Console.ReadLine();
				tryAgain = bool.Parse(myTryAgain);
            }
		}
	}
}
