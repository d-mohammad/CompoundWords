using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEW
{
	//handle all aspects of mapping the trie
	public class TrieMapper
	{
		public Dictionary<int, List<string>> treeMap = new Dictionary<int, List<string>>();
		public Trie trie = new Trie();

		//insert a new word then build the map to match
		public void buildTrie(string word)
		{
			trie.InsertWord(word);
			buildMap(word);
		}

		//used to update the tree map after we insert a new word
		public void buildMap(string word)
		{
			int key = word.Length;
			var wordList = (treeMap.Where(x => x.Key == key).Select(x => x.Value).ToList()).FirstOrDefault();

			if (wordList == null)
			{
				wordList = new List<string>();
				wordList.Add(word);
				treeMap.Add(key, wordList);
			}
			else
			{
				wordList.Add(word);
			}
		}

		//use the trie to check if it is a compound word
		public bool IsWordCompound(string word, bool isSingleWord)
		{
			int length = word.Length;
			if (trie.MatchesWord(word) && !isSingleWord)
			{
				return true;
			}

			for (int i = 0; i < length; i++)
			{
				//split the word in order to check for a compound word
				string firstPart = word.Substring(0, i);
				string lastPast = word.Substring(i);

				if (trie.MatchesWord(firstPart) && IsWordCompound(lastPast, false))
				{
					return true;
				}
			}

			return false;
		}
	}
}
