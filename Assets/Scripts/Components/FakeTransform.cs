﻿using UnityEngine;
using System.Collections;

public class FakeTransform : MonoBehaviour {
	public Vector2 position { get; set; }
	public GameObject[] neighbors = new GameObject[6];
}