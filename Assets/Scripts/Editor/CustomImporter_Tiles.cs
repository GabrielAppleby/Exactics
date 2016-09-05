using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Tiled2Unity.CustomTiledImporter]

public class CustomImporter_Tiles : Tiled2Unity.ICustomTiledImporter
{

	public void HandleCustomProperties(GameObject gameObject,
		IDictionary<string, string> customProperties)
	{
		FakeTransform test = gameObject.AddComponent<FakeTransform> ();
		Object.Destroy (gameObject.GetComponent<EdgeCollider2D> ());
	}

	public void CustomizePrefab(GameObject prefab)
	{
		// Do nothing
	}
}
