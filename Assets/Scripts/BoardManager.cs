using UnityEngine;
using UnityEditor;
using System.Collections;


public class BoardManager : MonoBehaviour {

	//Holds all the floor tiles in the Unity Window
	private Transform boardHolder;
	//Grid class that will store our tiles for easy access
	private Grid floorGrid;

	//Width of a hexagon
	private float hexWidth;
	//Height of a hexagon
	private float hexHeight;
	//The number of hexs in the largest row
	//Currently used to calculate board size
	private int maxNumHexs = 30;

	//Initializes the grid, and grabs the width and height of the hexs we are using
	void Init () {

		//Grid stores all the floor things
		floorGrid = new Grid ();
		boardHolder = new GameObject ("Board").transform;
		GameObject helper = CreateFloorTile ("Helper", new Coordinate(0, 0, 0, 0));
		hexWidth = helper.GetComponent<PolygonCollider2D>().bounds.size.x;
		hexHeight = helper.GetComponent<PolygonCollider2D>().bounds.size.y;
		floorGrid.Remove (helper);
		Destroy (helper);
	}


	GameObject CreateFloorTile (string name, Coordinate coord) {
		//Create a new empty game object
		GameObject floorTile = new GameObject (name + ": " + coord.x + "," + coord.y);

		//Update position to real coords
		floorTile.transform.position = new Vector2 (coord.xReal, coord.yReal);

		//Set parent for easy access
		floorTile.transform.SetParent (boardHolder);

		//Attach a sprite renderer
		SpriteRenderer spriteRenderer = floorTile.AddComponent <SpriteRenderer>();
		//Pick sprite
		spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath("Assets/Sprites/floor.png", typeof(Sprite));

		//Attach our tilescript
		TileScript tileScript = floorTile.AddComponent <TileScript>();

		//Initialize the tileScript
		tileScript.Init (coord, spriteRenderer);

		//Add a collider
		PolygonCollider2D test = floorTile.AddComponent<PolygonCollider2D>();
		//test.isTrigger = true;

		//Add it to our grid
		floorGrid.Add (floorTile);

		//Return the tile (only used for init)
		return floorTile;
	}

	void BoardSetup () {
		//Given the size of the grid we want to make
		//what is the number of rows on either side of the middle
		int numSmallerRows = maxNumHexs / 2;

		//Number of hexs in smallest row
		int minNumHexs = maxNumHexs - numSmallerRows;

		//The min x coord of a hex for the smallest row will be -1.5 of a hex
		float xInitial = (-minNumHexs * hexWidth) / 2f + (hexWidth / 2f);

		//The max x coord of a hex for the smallest row will be 1.5 of a hex
		float xMax = (minNumHexs * hexWidth) / 2f;

		//The x coord will move over by one hexWidth each time
		float xInterval = hexWidth;

		//The min y coord of a hex for the smallest row will be the number
		//of rows that are below 0, 0
		float yInitial = -numSmallerRows * hexHeight * (3f / 4f);

		//The max y coord of a hex for the smallest for will be the number
		//of rows that are above 0,0
		float yMax = (numSmallerRows + 1) * hexHeight * (3f / 4f);

		//The ty coord will move over by 3/4 of a hexheight each time
		float yInterval = hexHeight * (3f / 4f);

		//Lets me know if we're increasing in number of hexs per row or decreasing
		int yCount = 0;
		int xCount;
		for (float y = yInitial; y < yMax; y+=yInterval) {
			xCount = 0;
			for (float x = xInitial; x < xMax; x += xInterval) {
				CreateFloorTile ("floor", new Coordinate(x, y, xCount, yCount));
				xCount++;
			}
			yCount++;

			//If decreasing
			if (yCount > numSmallerRows) {
				//Start a bit further in
				xInitial += (hexWidth / 2f);
				//and end a bit sooner
				xMax -= (hexWidth / 2f);
			} 
			//If increasing
			else {
				//Start a bit further out
				xInitial -= (hexWidth / 2f);
				//End a bit later
				xMax += (hexWidth / 2f);
			}
				
		}
	}

	//Sets up the scene of the game
	public void SetupScene () {
		Init ();
		BoardSetup ();
		CreateUnit("test", floorGrid.Get (floorGrid.hashCode(10, 10)));
	}


	GameObject CreateUnit (string name, GameObject tile) {
		Coordinate coord = tile.GetComponent<TileScript>().coord;

		//Create a new empty game object
		GameObject unit = new GameObject (name + ": " + coord.x + "," + coord.y);
		unit.layer = 9;
		//Update position to real coords
		unit.transform.position = new Vector2 (coord.xReal, coord.yReal);

		//Set parent for easy access
		unit.transform.SetParent (boardHolder);

		//Attach a sprite renderer
		SpriteRenderer spriteRenderer = unit.AddComponent <SpriteRenderer>();
		//Pick sprite
		spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath("Assets/Sprites/unit.png", typeof(Sprite));
		spriteRenderer.sortingLayerName = "units";
		spriteRenderer.sortingOrder = 1;
		//Attach our tilescript
		TileScript tileScript = unit.AddComponent <TileScript>();
		//Initialize the tileScript
		tileScript.Init (coord, spriteRenderer);

		//Add a collider
		unit.AddComponent<PolygonCollider2D>();



		//Return the tile (only used for init)
		return unit;
	}
}
	