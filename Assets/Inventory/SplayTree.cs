using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


public class SplayTree<T> where T : IComparable {
	Node<T> root;
	public int count;

	public SplayTree() {
		root = null;
		count = 0;
	}

	//Compare method that uses comparator if available
	//and uses a natural comparator if not.
	private int compare(T x, T y){
		return x.CompareTo(y);
	}
	
	public void add(T x, int value) {
		this.set (x, value);
	}
	public T find (T key) {
		if (this.count == 0)
		{
			return default(T);
		}
		
		this.splay(key);
		if (key.CompareTo (this.root.key) == 0) {
			return key;
		}
		return default(T);
	}
	public bool check(T key, int value) {
		if (this.count == 0)
		{
			return false;
		}
		
		this.splay(key);
		if (key.CompareTo (this.root.key) == 0) {
			if (value <= this.root.value) {
				return true;
			}
		}
		return false;
	}
	public bool remove(T key, int value)
	{
		if (this.count == 0)
		{
			return false;
		}

		this.splay(key);

		if (key.CompareTo(this.root.key) != 0)
		{
			return false;
		}

		if (value < this.root.value) {
			this.root.value -= value;
			return true;
		} 
		else if (value > this.root.value) {
			return false;
		}

		if (this.root.left == null)
		{
			this.root = this.root.right;
		}
		else
		{
			var swap = this.root.right;
			this.root = this.root.left;
			this.splay(key);
			this.root.right = swap;
		}
		this.count--;
		return true;
	}
	public IList<T> Keys (){
		return this.AsList (node => node.key);
	}
	public IList<Node<T>> Nodes (){
		return this.AsList (node => node);
	}
	private IList<TEnumerator> AsList<TEnumerator>(Func<Node<T>, TEnumerator> selector)
	{
		if (this.root == null)
		{
			return new TEnumerator[0];
		}
		
		var result = new List<TEnumerator>(this.count);
		PopulateList(this.root, result, selector);
		return result;
	}
	
	private void PopulateList<TEnumerator>(Node<T> node, List<TEnumerator> list, Func<Node<T>, TEnumerator> selector)
	{
		if (node.left != null) PopulateList(node.left, list, selector);
		list.Add(selector(node));
		if (node.right != null) PopulateList(node.right, list, selector);
	}
	
	//Private methods -------------------------------------------------------------------------
	private void set(T key, int value)
	{
		if (this.count == 0)
		{
			this.root = new Node<T>(key, value);
			this.count = 1;
			return;
		}
		
		this.splay(key);
		
		var c = key.CompareTo(this.root.key);
		//If already exists in the tree add it to the existing node
		if (c == 0) {
			this.root.value += value;
			return;
		}
		
		var n = new Node<T>(key, value);
		if (c < 0) {
			n.left = this.root.left;
			n.right = this.root;
			this.root.left = null;
		}
		else {
			n.right = this.root.right;
			n.left = this.root;
			this.root.right = null;
		}
		
		this.root = n;
		this.count++;
		this.splay(key);
	}

	private void splay(T key) {
		Node<T> l, r, t, y, header;
		l = r = header = new Node<T>(default(T), 0);
		t = this.root;
		while (true) {
			var c = key.CompareTo(t.key);
			if (c < 0) {
				if (t.left == null) break;
				if (key.CompareTo(t.left.key) < 0) {
					y = t.left;
					t.left = y.right;
					y.right = t;
					t = y;
					if (t.left == null) break;
				}
				r.left = t;
				r = t;
				t = t.left;
			}
			else if (c > 0) {
				if (t.right == null) break;
				if (key.CompareTo(t.right.key) > 0)
				{
					y = t.right;
					t.right = y.left;
					y.left = t;
					t = y;
					if (t.right == null) break;
				}
				l.right = t;
				l = t;
				t = t.right;
			}
			else
			{
				break;
			}
		}
		l.right = t.left;
		r.left = t.right;
		t.left = header.right;
		t.right = header.left;
		this.root = t;
	}

	//Calculates the max level out of all the nodes
	private int maxLevel(Node<T> node) {
		if (node == null){
			return 0;
		}
		return 1 + Math.Max(maxLevel(node.left), maxLevel(node.right));
	}
}