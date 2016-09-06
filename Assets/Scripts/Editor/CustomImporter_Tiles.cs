using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Tiled2Unity.CustomTiledImporter]

public class CustomImporter_Tiles : Tiled2Unity.ICustomTiledImporter
{

	public void HandleCustomProperties(GameObject gameObject,
		IDictionary<string, string> customProperties)
	{
		Debug.Log (gameObject);
		FakeTransform test = gameObject.AddComponent<FakeTransform> ();
		PolygonCollider2D poly = gameObject.AddComponent<PolygonCollider2D> ();
		Debug.Log (test);
		Object.DestroyImmediate (gameObject.GetComponent<EdgeCollider2D> ());
	}

	public void CustomizePrefab(GameObject prefab)
	{
		Debug.Log ("butts ha");
		// Do nothing
	}
}
