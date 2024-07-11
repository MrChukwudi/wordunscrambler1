using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler
{
	public class UnscrambleOperation
	{
		
		public List<string> ReadFile(string path)
		{
			List<string> readList = new List<string>();
			string[] wordArray = File.ReadAllLines(path);
			foreach(var word in wordArray)
			{
				readList.Add(word);
			}
			return readList;
		}

		public List<string> ReadInput()
		{
			Console.WriteLine("Enter the List of unscrambled words seperated by a comma");
			string? unscrambleString = Console.ReadLine();

			List<string> myList = new List<string>();

			if (unscrambleString != null)
			{
				foreach (var str in unscrambleString.Split(","))
				{
					myList.Add(str.Trim());
				}
			}

			return myList;
		}


		public List<string> UnscrambleWords(List<string> scrambled, List<string> unscrambled)
		{
			List<string> matched = new List<string>();

			foreach (var scrambledWord in scrambled)
			{
				foreach (var unscrambledWord in unscrambled)
				{
					if (scrambledWord.Length == unscrambledWord.Length)
					{
						var sortedScrambled = String.Concat(scrambledWord.OrderBy(c => c)).ToLower();
						var sortedUnscrambled = String.Concat(unscrambledWord.OrderBy(c => c)).ToLower();

						if (sortedScrambled == sortedUnscrambled)
						{
							matched.Add($"{scrambledWord} matched {unscrambledWord}");
						}
					}
				}
			}

			if(matched.Count == 0)
			{
				matched.Add("There was no match");
			}

			return matched;
		}

	}
}
