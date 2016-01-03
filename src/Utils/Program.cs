using ChallengeUtils.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
	class Program
	{
		static void Main(string[] args)
		{

			Node<string> t1 = new Node<string>("test2", "Node2");
			Node<string> t2 = new Node<string>("test3", "Node3");
			Node<string> newChild2 = new Node<string>("test5", "Node5");
			Node<string> newChild1 = new Node<string>("test4", "Node4");
			Node<string> root = new Node<string>("test1", null, "RootNode");

			newChild1.AddExistingChild(newChild2);
			root.AddExistingChild(t1).AddExistingChild(t2).AddExistingChild(newChild1);
			var res = root.Select(a => a);
			foreach (var abc in res) {
				Console.WriteLine(abc.NodeId);
			}

			Console.ReadLine();
		}
	}
}
