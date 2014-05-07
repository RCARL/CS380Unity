using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

[Serializable()]
public class Node<T>{
	public T key;
	public int value;
	public Node<T> left;
	public Node<T> right;

	public Node(T key, int value) {
		this.key = key;
		this.value = value;
	}
}

