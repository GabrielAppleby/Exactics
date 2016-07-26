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


	//Sets up the test scene of the game
	public void setupScene () {
		init ();
		boardSetup ();
		createUnit("test", floorGrid.get (floorGrid.hashCode(10, 10)).coord);
	}


	//Initializes the grid, and grabs the width and height of the hexs we are using
	private void init () {

		//Grid stores all the floor things
		floorGrid = new Grid ();
		boardHolder = new GameObject ("Board").transform;
		TileScript helper = createFloorTile ("Helper", new Coordinate(0, 0, 0, 0));
		hexWidth = helper.gameObject.GetComponent<PolygonCollider2D>().bounds.size.x;
		hexHeight = helper.gameObject.GetComponent<PolygonCollider2D>().bounds.size.y;
		Destroy (helper.gameObject);
	}
		

	private void boardSetup () {
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
				floorGrid.add(createFloorTile ("floor", new Coordinate(x, y, xCount, yCount)));
				//Add it to our grid
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

	private GameObject createObject (string name, Coordinate coord, string spritePath) {
		GameObject tempObject = new GameObject (name + ": " + coord.x + "," + coord.y);

		//Update position to real coords
		tempObject.transform.position = new Vector2 (coord.xReal, coord.yReal);

		//Attach a sprite renderer
		SpriteRenderer spriteRenderer = tempObject.AddComponent <SpriteRenderer>();

		//Pick sprite
		spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath(spritePath, typeof(Sprite));

		//Add a collider
		PolygonCollider2D test = tempObject.AddComponent<PolygonCollider2D>();

		return tempObject;

	}


	private TileScript createFloorTile (string name, Coordinate coord) {
		
		GameObject floorTile = createObject (name, coord, "Assets/Sprites/floor.png");
		SpriteRenderer spriteRenderer = floorTile.GetComponent<SpriteRenderer>();

		//Set parent for easy access
		floorTile.transform.SetParent (boardHolder);

		//Attach our tilescript
		TileScript tileScript = floorTile.AddComponent <TileScript>();

		//Initialize the tileScript
		tileScript.init (coord, spriteRenderer);

		return tileScript;
	}



	public UnitScript createUnit (string name, Coordinate coord) {


		GameObject unit = createObject (name, coord, "Assets/Sprites/unit.png");
		SpriteRenderer spriteRenderer = unit.GetComponent<SpriteRenderer>();



		unit.layer = 9;

		//Pick sprite
		spriteRenderer.sortingLayerName = "units";
		spriteRenderer.sortingOrder = 1;
		//Attach our tilescript
		UnitScript unitScript = unit.AddComponent <UnitScript>();
		//Initialize the tileScript
		unitScript.init (Constants.Classes.Dragon, Constants.Races.Dragon);
		unitScript.tileScript = floorGrid.get (coord);

		return unitScript;
	}
}
	