using UnityEngine;
using UnityEditor;
using System.Collections;


public class BoardManager : MonoBehaviour {

	//Grid class that will store our tiles for easy access
	private Grid grid;
	private ObjectFactory objectFactory;

	//Width of a hexagon
	private readonly float hexWidth = .88f;
	//Height of a hexagon
	private readonly float hexHeight = 1f;
	//The number of hexs in the largest row
	//Currently used to calculate board size
	private readonly int maxNumHexs = 20;

	//Delete me
	GameObject unit;



	//First thing that happens
	//Happens even if component not enabled
	private void Awake () {

	}

	//Happens after awake, before first update.
	//Does not happen if component not enabled
	private void Start () {
		this.objectFactory = new ObjectFactory ();
		this.grid = new Grid ();
		createBoard ();
		objectFactory.position = new Vector2 (-1.32f, -1.5f);
		objectFactory.fakePosition = new Vector2 (-3f, 2f);
		unit = objectFactory.createUnit ();
	}

	private void createBoard () {
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
		int q;
		int r = numSmallerRows;
		for (float y = yInitial; y < yMax; y+=yInterval) {
			xCount = 0;
			q = -numSmallerRows;
			for (float x = xInitial; x < xMax; x += xInterval) {
				objectFactory.position = new Vector2 (x, y);
				objectFactory.fakePosition = new Vector2 (q, r);
				grid.add (objectFactory.createTile());
				//Add it to our grid
				xCount++;
				q++;
			}
			yCount++;
			r--;

			//If decreasing
			if (yCount > numSmallerRows) {
				//Start a bit further in
				xInitial += (hexWidth / 2f);
				//and end a bit sooner
				xMax -= (hexWidth / 2f);
				numSmallerRows--;
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
		
}
	