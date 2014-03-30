/*
 * This code implements priority queue which uses min-heap as underlying storage
 * 
 * Copyright (C) 2010 Alexey Kurakin
 * www.avk.name
 * alexey[ at ]kurakin.me
 */

using System;
using System.Collections;
using System.Collections.Generic;

    /// <summary>
    /// Priority queue based on binary heap,
    /// Elements with minimum priority dequeued first
    /// </summary>
    /// <typeparam name="TPriority">Type of priorities</typeparam>
    /// <typeparam name="TValue">Type of values</typeparam>
public class PriorityQueue<P, V>
{
	private SortedDictionary<P, LinkedList<V>> list = new SortedDictionary<P, LinkedList<V>>();
	
	public void Enqueue(P priority, V value)
	{
		LinkedList<V> q;
		if (!list.TryGetValue(priority, out q))
		{
			q = new LinkedList<V>();
			list.Add(priority, q);
		}
		q.AddLast(value);
	}
	
	public V Dequeue()
	{
		// will throw exception if there isn’t any first element!
		SortedDictionary<P, LinkedList<V>>.KeyCollection.Enumerator enume = list.Keys.GetEnumerator();
		enume.MoveNext();
		P key = enume.Current;
		LinkedList<V> v = list[key];
		V res = v.First.Value;
		v.RemoveFirst();
		if (v.Count == 0){ // nothing left of the top priority.
			list.Remove(key);
		}
		return res;
	}
	
	
	
	public void Replace(V value, P oldPriority, P newPriority){
		LinkedList<V> v = list[oldPriority];
		v.Remove(value);
		
		if (v.Count == 0){ // nothing left of the top priority.
			list.Remove(oldPriority);
		}
		
		Enqueue(newPriority,value);
	}
	
	public bool IsEmpty
	{
		get { return list.Count==0; }
	}
	
	public override string ToString() {
		string res = "";
		foreach (P key in list.Keys){
			foreach (V val in list[key]){
				res += val+", ";
			}
		}
		return res;
	}
}
