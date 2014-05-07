using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

[Serializable()]
public class Node<T> : ISerializable{
	public T key;
	public int value;
	public Node<T> left;
	public Node<T> right;

	public Node(T key, int value) {
		this.key = key;
		this.value = value;
	}

	public Node(SerializationInfo info, StreamingContext context) {
		// Reset the property value using the GetValue method.
		left = (Node<T>) info.GetValue("left", typeof(Node<T>));
		right = (Node<T>) info.GetValue ("right", typeof(Node<T>));
		key = (T) info.GetValue ("key", typeof(T));
		value = (int)info.GetValue ("value", typeof(int));
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context) {
		// Use the AddValue method to specify serialized values.
		info.AddValue("left", left, typeof(Node<T>));
		info.AddValue("right", right, typeof(Node<T>));
		info.AddValue("key", key, typeof(T));
		info.AddValue("value", value, typeof(int));
	}
}

