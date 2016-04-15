using Fluttert;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Fluttert.Utils.Tree;

namespace Utils.Tree
{
	[TestClass()]
	public class NodeTests
	{
		[TestMethod()]
		public void CreateSingleStringNodeTest()
		{
			Node<string> t1 = new Node<string>("test");
			Assert.AreEqual(t1.Value, "test");
			Assert.IsTrue(t1.IsLeaf);
			Assert.IsTrue(t1.IsRoot);
			Assert.IsTrue(t1.IsAlone);
			Assert.AreEqual(t1.Level, 0);
			Assert.IsNull(t1.NodeId);
			Assert.IsNull(t1[0]);
		}

		[TestMethod()]
		public void CreateSingleStringNodeWithRefTest()
		{
			Node<string> t1 = new Node<string>("test", null, "TestRef");
			Assert.AreEqual(t1.Value, "test");
			Assert.IsTrue(t1.IsLeaf);
			Assert.IsTrue(t1.IsRoot);
			Assert.IsTrue(t1.IsAlone);
			Assert.AreEqual(t1.Level, 0);
			Assert.AreEqual(t1.NodeId, "TestRef");
			Assert.IsNull(t1[0]);

			t1.UpdateValue("testUpdate");
			Assert.AreEqual("testUpdate", t1.Value);
		}

		[TestMethod()]
		public void CreateMultipleStringNodeTest()
		{
			Node<string> root = new Node<string>("test1", null, "RootNode");
			Node<string> t1 = new Node<string>("test2", null, "Node2");
			Node<string> t2 = new Node<string>("test3", null, "Node3");
			root.AddExistingChild(t1);
			root.AddExistingChild(t2);
			var newChild1 = root.AddNewChild("test4", "Node4");
			var newChild2 = newChild1.AddNewChild("test5", "Node5");

			// do some tests on this tree
			Assert.AreNotEqual(t1, t2);                 // basic object comparisson
			Assert.AreNotEqual(newChild1, newChild2);   // basic object comparisson while build on the fly
			Assert.AreEqual(root.Children.Count, 3);    // children correctly added?
			Assert.AreSame(t1, root[0]);                // in-order adding of children
			Assert.AreNotSame(t1, root[1]);             // in-order adding of children
			Assert.AreSame(newChild1, root[2]);         // check if add method works as advertised
			Assert.AreSame(root[2][0], newChild2);      // check if multiple [X] works as expected
			Assert.AreEqual(newChild2.Level, 2);
			Assert.IsTrue(newChild2.IsLeaf);
			Assert.IsFalse(newChild1.IsLeaf);
			Assert.IsFalse(newChild1.IsRoot);
			Assert.IsTrue(root.IsRoot);
			Assert.IsFalse(root.IsAlone);
			Assert.IsFalse(root.IsLeaf);
			Assert.AreSame(t1.Parent, root);
			Assert.AreEqual(t2.Parent.NodeId, "RootNode");
			Assert.AreSame(newChild1.Parent, root);
		}

		[TestMethod()]
		public void CreateMultipleStringNodeOutOfOrderTest()
		{
			Node<string> t1 = new Node<string>("test2", "Node2");
			Node<string> t2 = new Node<string>("test3", "Node3");
			Node<string> newChild2 = new Node<string>("test5", "Node5");
			Node<string> newChild1 = new Node<string>("test4", "Node4");
			Node<string> root = new Node<string>("test1", null, "RootNode");

			newChild1.AddExistingChild(newChild2);
			root.AddExistingChild(t1).AddExistingChild(t2).AddExistingChild(newChild1);

			// do some tests on this tree
			Assert.AreNotEqual(t1, t2);                 // basic object comparisson
			Assert.AreNotEqual(newChild1, newChild2);   // basic object comparisson while build on the fly
			Assert.AreEqual(root.Children.Count, 3);    // children correctly added?
			Assert.AreSame(t1, root[0]);                // in-order adding of children
			Assert.AreNotSame(t1, root[1]);             // in-order adding of children
			Assert.AreSame(newChild1, root[2]);         // check if add method works as advertised
			Assert.AreSame(root[2][0], newChild2);      // check if multiple [X] works as expected
			Assert.AreEqual(newChild2.Level, 2);
			Assert.IsTrue(newChild2.IsLeaf);
			Assert.IsFalse(newChild1.IsLeaf);
			Assert.IsFalse(newChild1.IsRoot);
			Assert.IsTrue(root.IsRoot);
			Assert.IsFalse(root.IsAlone);
			Assert.IsFalse(root.IsLeaf);
			Assert.AreSame(t1.Parent, root);
			Assert.AreEqual(t2.Parent.NodeId, "RootNode");
			Assert.AreSame(newChild1.Parent, root);
		}

		[TestMethod()]
		public void CyclePrevention()
		{
			Node<string> t1 = new Node<string>("test1", "Node1");
			Node<string> t2 = new Node<string>("test2");
			Node<string> t3 = new Node<string>("test3");

			t1.AddExistingChild(t2);
			Assert.AreSame(t2, t1[0]);          // first child = t2
			Assert.AreSame(t2.Parent, t1);      // parent = t1
			Assert.IsFalse(t1.CyclePrevented);  // no cycle

			t2.AddExistingChild(t1);            // try to add child (should fail)
			Assert.IsNull(t2[0]);               // no child added
			Assert.IsTrue(t2.CyclePrevented);   // Cycle is prevented!
			Assert.IsNull(t1.Parent);           // no parent is set
			Assert.AreEqual(1, t2.Level);

			t2.AddExistingChild(t3);
			Assert.AreSame(t3, t2[0]);          // valid child
			Assert.IsFalse(t2.CyclePrevented);  // not cycle prevented, cuz there wasnt one
			Assert.AreEqual(2, t3.Level);
			Assert.AreEqual(0, t1.Level);

			Assert.IsFalse(t3.CyclePrevented);   // default value
			t3.AddExistingChild(t1);
			Assert.IsNull(t3[0]);               // no child added
			Assert.IsTrue(t3.CyclePrevented);   // Cycle is prevented!
			Assert.IsNull(t1.Parent);           // no parent is set
		}

		[TestMethod()]
		public void IEnumerableTest()
		{
			Node<string> root = new Node<string>("test1", null, "RootNode");
			Node<string> t1 = new Node<string>("test2", "Node2");
			Node<string> t2 = new Node<string>("test3", "Node3");
			Node<string> newChild1 = new Node<string>("test4", "Node4");
			Node<string> newChild2 = new Node<string>("test5", "Node5");

			newChild1.AddExistingChild(newChild2);
			root.AddExistingChild(t1).AddExistingChild(t2).AddExistingChild(newChild1);

			var list1 = new List<Node<string>>() { t1, t2, newChild1 };
			var list2 = new List<Node<string>>() { t1, t2 };

			Assert.AreEqual(3, root.Count());
			CollectionAssert.AreEqual(list1, root.ToList());
			CollectionAssert.AreEqual(list2, root.Where(a => a.NodeId!= "Node4").ToList());
			
		}
	}
}