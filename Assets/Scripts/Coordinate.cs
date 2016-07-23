using UnityEngine;
using System.Collections;

public class Coordinate {
	public float xReal { get; set; }
	public float yReal { get; set; }


	public int x { get; set; }
	public int y { get; set; }

	public Coordinate (float xReal, float yReal, int x, int y) {
		this.xReal = xReal;
		this.yReal = yReal;
		this.x = x;
		this.y = y;
	}
		
}
