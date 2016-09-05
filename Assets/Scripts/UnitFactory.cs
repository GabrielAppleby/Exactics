using UnityEngine;
using System.Collections;



//Will switch this to a more robust pattern as the game scales up

public class UnitFactory {
	private readonly GameObject parentUnit;
	private readonly Transform parentUnitTransform;
	private readonly string unitSpriteName;
	private readonly Sprite unitSprite;
	private readonly string unitName;
	public Vector2 fakePosition { get; set; }
	public Vector2 position { get; set; }

	public UnitFactory() {
		position = new Vector2(0, 0);
		fakePosition = new Vector2 (0, 0);

		parentUnit = new GameObject ("Unit Holder");
		parentUnitTransform = parentUnit.GetComponent<Transform> ();
		unitSpriteName = "Ephraim.png";
		unitSprite = (Sprite)Resources.Load (unitSpriteName);

		unitName = "Unit";
	}
		

	public GameObject createUnit()
	{
		GameObject unit = new GameObject (unitName);
		unit.GetComponent<Transform>().position = position;
		FakeTransform fakeTransform = unit.AddComponent<FakeTransform> ();
		fakeTransform.position = fakePosition;
		unit.transform.SetParent (parentUnitTransform);
		SpriteRenderer spriteRenderer = unit.AddComponent <SpriteRenderer>();
		spriteRenderer.sprite = unitSprite;
		spriteRenderer.sortingOrder = 1;
		unit.AddComponent<PolygonCollider2D>();
		unit.AddComponent<Defense> ();
		unit.AddComponent<Initiative> ();
		unit.AddComponent<Mana> ();
		unit.AddComponent<Stamina> ();
		unit.AddComponent<Movement> ();
		unit.AddComponent<Offense> ();
		unit.AddComponent<Input> ();
		return unit;
	}



}
