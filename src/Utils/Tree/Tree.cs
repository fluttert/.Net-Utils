using System;
using System.Collections;
using System.Collections.Generic;

namespace ChallengeUtils.Tree
{
	/// <summary>Generic Node class, usable in tree-structures</summary>
	/// <typeparam name="T">Generic type</typeparam>
	/// <author>Ernst Fluttert // Nare_man</author>
	/// <remarks>
	/// Based on http://stackoverflow.com/questions/66893/tree-data-structure-in-c-sharp ;
	/// </remarks>
	public class Node<T> : IEnumerable<Node<T>>
	{
		private Node<T> _parent;
		public readonly string NodeId;
		public T Value { get; private set; }                                // the value it should have
		public Node<T> Parent                                               // parent can only be set once (or explicit delete and reattach)
		{
			get { return _parent; }
			set
			{
				if (_parent == null && value != null)
				{
					_parent = value;
					UpdateLevel();
				}
			}
		}
		public List<Node<T>> Children { get; private set; }                 // Empty list on default
		public bool IsLeaf { get { return Children.Count == 0; } }          // no children = leaf
		public bool IsRoot { get { return Parent == null; } }               // no parent == root
		public bool IsAlone { get { return IsLeaf && IsRoot; } }            // all alone?
		public int Level { get; private set; }                              // standard zero for root
		public bool CyclePrevented { get; private set; }

		/// <summary>Get a childnode immediately</summary>
		/// <param name="index"></param>
		/// <returns>Node of type T or null if out of range</returns>
		public Node<T> this[int index]
		{
			get
			{
				if (index < Children.Count) { return Children[index]; }
				return null;
			}
		}

		/// <summary>Create a node for a tree structure</summary>
		/// <param name="nodeValue">The value (data) for this node</param>
		/// <param name="nodeParent">Parent object or default (empty)</param>
		/// <param name="nodeId">NodeId to be used as a key</param>
		public Node(T nodeValue, Node<T> nodeParent = null, string nodeId = null)
		{
			Value = nodeValue;
			Parent = nodeParent;
			NodeId = nodeId;
			Children = new List<Node<T>>();
		}

		/// <summary>
		/// Shorthand constructor for quickly constructing a node with a reference only
		/// </summary>
		/// <param name="nodeValue">The valude of this node</param>
		/// <param name="nodeId">A reference for this node</param>
		public Node(T nodeValue, string nodeId) : this(nodeValue, null, nodeId)
		{
		}

		/// <summary>Update the value of this node</summary>
		/// <param name="value">The new value</param>
		/// <returns>This node</returns>
		public Node<T> UpdateValue(T value)
		{
			Value = value;
			return this;
		}

		/// <summary>Disconnects this node from the parent</summary>
		/// <returns>The current node</returns>
		/// <remarks>This also updates all underlying nodes</remarks>
		protected Node<T> NoParent()
		{
			_parent = null;
			UpdateLevel();
			Traverse(node => node.UpdateLevel());
			return this;
		}

		/// <summary>Updates the current level</summary>
		/// <remarks>This is often needed when the node it added out-of-order (new parent)</remarks>
		protected void UpdateLevel()
		{
			if (_parent != null) { Level = _parent.Level + 1; }
			else { Level = 0; } // reset to default
		}

		/// <summary>Adds an existing Node as a child to this Node</summary>
		/// <param name="child">The child node to be added</param>
		/// <returns>The current node</returns>
		/// <remarks>
		/// Child may not have a parent-node yet! Underlying subtree will have an update level
		/// </remarks>
		public Node<T> AddExistingChild(Node<T> child)
		{
			// only add the child, if doesnt have a parent, or the parent is this object
			if (child.Parent == null || child.Parent == this)
			{
				child.Parent = this;                     // sets the parent
				if (WillAddCauseCycle()) { child.NoParent(); return this; }
				child.Traverse(node => node.UpdateLevel());   // this updates ALL levels of the existing childs
				Children.Add(child);
			}
			return this;
		}

		/// <summary>Helper function to detect if a cycle is present by going to all ancestors</summary>
		/// <returns>Bool, true if an ancestor node is equal to itself</returns>
		private bool WillAddCauseCycle()
		{
			Node<T> ancestorNode = Parent;
			while (ancestorNode != null)
			{
				if (ancestorNode == this) { CyclePrevented = true; return true; }
				ancestorNode = ancestorNode.Parent;
			}
			CyclePrevented = false;
			return false;
		}

		/// <summary>Creates and adds a new child-node</summary>
		/// <param name="child">Data of the child</param>
		/// <param name="nodeId">Possible reference</param>
		/// <returns>The newly created node</returns>
		public Node<T> AddNewChild(T child, string nodeId = null)
		{
			var newChild = new Node<T>(child, this, nodeId);
			AddExistingChild(newChild);
			return newChild;
		}

		/// <summary>Generic traversal on tree structure for an Action on this node + subnodes</summary>
		/// <param name="action">
		/// Action / Anonymous function applied to this and all an all underlying nodes
		/// </param>
		/// <remarks>Use ONLY in Tree structures // A-Cyclic</remarks>
		public void Traverse(Action<Node<T>> action)
		{
			action(this);
			foreach (var child in Children)
			{
				child.Traverse(action);
			}
		}

		#region IEnumberable interface implementation

		/// <summary>
		/// Quick IEnumerator for querying the child-nodes
		/// </summary>
		/// <returns>IEnumerator of Node</returns>
		public IEnumerator<Node<T>> GetEnumerator()
		{
			return Children.GetEnumerator();
		}

		// returns  a generic enumerator object
		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
		#endregion IEnumberable interface implementation
	}
}