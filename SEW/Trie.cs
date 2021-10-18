using System.Collections.Generic;

namespace SEW
{
	public class Trie
	{
		Node rootNode;

		//create the root node with an empty value
		public Trie()
		{
			rootNode = new Node(' ');
		}

		//set up the node class, typical to a Trie structure
		public class Node { 
			public char Value { get; set; }

			public bool EndOfWord { get; set; }

			public List<Node> Children { get; set; }


			public Node (char ch)
			{
				this.Value = ch;
				this.EndOfWord = false;
				this.Children = new List<Node>();
			}			

			public Node GetChildNodeByChar(char input) { 
				if (Children.Count > 0)
				{
					foreach (Node child in Children)
					{
						if (child.Value == input)
						{
							return child;
						}
					}					
				}

				return null;
			}			
		}

		//add a method for inserting a new word and adding a new child where non existent
		public void InsertWord(string word)
		{
			Node currentNode = rootNode;
			int length = word.Length;
			char ch;

			for(int i = 0; i < length; i++)
			{
				ch = word[i];
				Node child = currentNode.GetChildNodeByChar(ch);

				if (child == null)
				{
					currentNode.Children.Add(new Node(ch));
					currentNode = currentNode.GetChildNodeByChar(ch);
				}
				else
				{
					currentNode = child;
				}
				if (i == length - 1)
				{
					currentNode.EndOfWord = true;
				}
			}
		}

		//use the trie to find a match. if the last node found ends in a word, this means we have a match
		public bool MatchesWord(string word)
		{
			Node currentNode = rootNode;
			int length = word.Length;
			char ch;

			while (currentNode != null)
			{
				for(int i = 0; i < length; i++)
				{
					ch = word[i];
					if (currentNode.GetChildNodeByChar(ch) == null)
					{
						return false;
					}
					else
					{
						currentNode = currentNode.GetChildNodeByChar(ch);
					}
				}
				if (currentNode.EndOfWord == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			return false;
		}
	}
}
