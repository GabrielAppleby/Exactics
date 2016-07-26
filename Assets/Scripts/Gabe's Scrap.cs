/*// ----------------------------------------------------------------------------
// Tuple structs for use in .NET Not-Quite-3.5 (e.g. Unity3D).
//
// Used Chapter 3 in http://functional-programming.net/ as a starting point.
//
// Note: .NET 4.0 Tuples are immutable classes so they're *slightly* different.
// ----------------------------------------------------------------------------
//Shamelessly stolen and not necessary
using System;

/// <summary>
/// Represents a functional tuple that can be used to store
/// two values of different types inside one object.
/// </summary>
/// <typeparam name="T1">The type of the first element</typeparam>
/// <typeparam name="T2">The type of the second element</typeparam>
public sealed class Tuple<T1, T2>
{
	private readonly T1 item1;
	private readonly T2 item2;

	/// <summary>
	/// Retyurns the first element of the tuple
	/// </summary>
	public T1 Item1
	{
		get { return item1; }
	}

	/// <summary>
	/// Returns the second element of the tuple
	/// </summary>
	public T2 Item2
	{
		get { return item2; }
	}

	/// <summary>
	/// Create a new tuple value
	/// </summary>
	/// <param name="item1">First element of the tuple</param>
	/// <param name="second">Second element of the tuple</param>
	public Tuple(T1 item1, T2 item2)
	{
		this.item1 = item1;
		this.item2 = item2;
	}

	public override string ToString()
	{
		return string.Format("Tuple({0}, {1})", Item1, Item2);
	}

	public override int GetHashCode()
	{
		int hash = 17;
		hash = hash * 23 + (item1 == null ? 0 : item1.GetHashCode());
		hash = hash * 23 + (item2 == null ? 0 : item2.GetHashCode());
		return hash;
	}

	public override bool Equals(object o)
	{
		if (!(o is Tuple<T1, T2>)) {
			return false;
		}

		var other = (Tuple<T1, T2>) o;

		return this == other;
	}

	public bool Equals(Tuple<T1, T2> other)
	{
		return this == other;
	}

	public static bool operator==(Tuple<T1, T2> a, Tuple<T1, T2> b)
	{
		if (object.ReferenceEquals(a, null)) {
			return object.ReferenceEquals(b, null);
		}
		if (a.item1 == null && b.item1 != null) return false;
		if (a.item2 == null && b.item2 != null) return false;
		return
			a.item1.Equals(b.item1) &&
			a.item2.Equals(b.item2);
	}

	public static bool operator!=(Tuple<T1, T2> a, Tuple<T1, T2> b)
	{
		return !(a == b);
	}

	public void Unpack(Action<T1, T2> unpackerDelegate)
	{
		unpackerDelegate(Item1, Item2);
	}
}
*/


/*
SliderScript temp;
int i;
foreach (Slider slider in sliders) {
	temp = slider.GetComponent<SliderScript> ();
	unitScript.stats.TryGetValue (temp.stat, out i);
	temp.updateSlider((float) i);
}*/

//
/*(GameObject sliderHolder = GameObject.Find ("Sliders");
sliders = new ArrayList();
foreach (Transform child in sliderHolder.transform)
{
	sliders.Add(child.GetComponent<Slider> ());
}*/


/*GameObject canvasObject = new GameObject ("Canvas");
canvasObject.AddComponent<RectTransform> ();
Canvas canvas = canvasObject.AddComponent<Canvas> ();
canvas.renderMode = RenderMode.ScreenSpaceOverlay;
canvasObject.AddComponent<CanvasScaler> ();
canvasObject.AddComponent<GraphicRaycaster> ();
canvasObject.AddComponent<CanvasRenderer> ();
canvasObject.AddComponent<Image> ();
GameObject events = new GameObject ("EventSystem");
GameObject dropDown = new GameObject ("Dropdown");
dropDown.transform.SetParent(canvasObject.transform);
RectTransform rectTransform = dropDown.AddComponent<RectTransform> ();
dropDown.AddComponent<CanvasRenderer> ();
dropDown.AddComponent<Image> ();
dropDown.AddComponent<Dropdown> ();
GameObject label = new GameObject ("Label");
label.AddComponent<RectTransform> ();
label.AddComponent<CanvasRenderer> ();
label.AddComponent<Text> ();
label.transform.SetParent(dropDown.transform);

GameObject arrow = new GameObject ("Arrow");
arrow.AddComponent<RectTransform> ();
arrow.AddComponent<CanvasRenderer> ();
arrow.AddComponent<Image> ();
arrow.transform.SetParent(dropDown.transform);*/


//A* to find path
/*public void findPath(TileScript start, TileScript goal) {
		PriorityQueue<TileScript> frontier = new PriorityQueue<TileScript> ();
		frontier.Enqueue (start, 0);
		Dictionary<TileScript, TileScript> cameFrom = new Dictionary<TileScript, TileScript>();
		Dictionary<TileScript, int> cost = new Dictionary<TileScript, int>();
		cameFrom.Add (start, null);
		cost.Add (start, 0);

		TileScript current;
		while (frontier.Count != 0) {
			current = frontier.Dequeue();
			if (current == goal) {
				break;
			}

			foreach (TileScript neighbor in getNeighbors(current)) {
				int temp;
				cost.TryGetValue (current, out temp);
				int newCost =  temp + 1;
				int value;
				int priority;
				cost.TryGetValue (neighbor, out value);
				if (cost.ContainsKey(neighbor) != true || newCost < value) {
					cost.Add(neighbor, value);
					priority = newCost + heuristic(goal, neighbor);
					frontier.Enqueue (neighbor, priority);
					cameFrom.Add(neighbor, current);
				}
			}
		}
	}*/

/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//Shamelessly stolen need to replace
//also not very efficient
public class PriorityQueue<T>
{
	// I'm using an unsorted array for this example, but ideally this
	// would be a binary heap. Find a binary heap class:
	// * https://bitbucket.org/BlueRaja/high-speed-priority-queue-for-c/wiki/Home
	// * http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
	// * http://xfleury.github.io/graphsearch.html
	// * http://stackoverflow.com/questions/102398/priority-queue-in-net

	private List<Tuple<T, double>> elements = new List<Tuple<T, double>>();

	public int Count
	{
		get { return elements.Count; }
	}

	public void Enqueue(T item, double priority)
	{
		elements.Add(new Tuple<T, double>(item, priority));
	}

	public T Dequeue()
	{
		int bestIndex = 0;

		for (int i = 0; i < elements.Count; i++) {
			if (elements[i].Item2 < elements[bestIndex].Item2) {
				bestIndex = i;
			}
		}

		T bestItem = elements[bestIndex].Item1;
		elements.RemoveAt(bestIndex);
		return bestItem;
	}
}
*/