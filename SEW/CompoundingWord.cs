using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static SEW.Trie;

namespace SEW
{
	class CompoundingWord
	{
		//use the TrieManager in order to handle the checks
		public static TrieMapper trieMapper = new TrieMapper();

		static void Main(string[] args)
		{
			//get file location (making sure file is copied to build directory)
			string fileName = "TestInputSets/shortTest.txt";

			//read file into list and order it by the length of words
			List<string> inputList = File.ReadAllLines(fileName).OrderByDescending(x => x.Length).ToList();
			HashSet<string> compoundWords = new HashSet<string>();

			inputList.ForEach(word => trieMapper.buildTrie(word));

			inputList.ForEach(word =>
			{
				if (trieMapper.IsWordCompound(word, true))
				{
					compoundWords.Add(word);
				}
			});
		}		
	}
}
