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
		unitSpriteName = "Ephraim";
		unitSprite = (Sprite) Resources.Load<Sprite> (unitSpriteName);

		unitName = "Unit";
	}
		
	//Adds all the components necessary to be a unit
	public GameObject createUnit()
	{
		GameObject unit = new GameObject (unitName);
		unit.GetComponent<Transform>().position = position;
		FakeTransformComponent fakeTransform = unit.AddComponent<FakeTransformComponent> ();
		fakeTransform.position = fakePosition;
		unit.transform.SetParent (parentUnitTransform);
		SpriteRenderer spriteRenderer = unit.AddComponent <SpriteRenderer>();
		spriteRenderer.sprite = unitSprite;
		spriteRenderer.sortingOrder = 2;
		unit.AddComponent<PolygonCollider2D>();
		unit.AddComponent<DefenseComponent> ();
		unit.AddComponent<InitiativeComponent> ();
		unit.AddComponent<ManaComponent> ();
		unit.AddComponent<StaminaComponent> ();
		unit.AddComponent<MovementComponent> ();
		unit.AddComponent<OffenseComponent> ();
		unit.AddComponent<InputComponent> ();
		unit.AddComponent<TeamComponent> ();
		return unit;
	}





}
