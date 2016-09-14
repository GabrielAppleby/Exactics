using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Tiled2Unity.CustomTiledImporter]

public class CustomImporter_Tiles : Tiled2Unity.ICustomTiledImporter
{

	public void HandleCustomProperties(GameObject gameObject,
		IDictionary<string, string> customProperties)
	{

	}

	//Customize the prefab so that fake coordinates
	//and neighbors don't need to be created at runtime
	public void CustomizePrefab(GameObject mapPrefab)
	{
		

	}
		
}

