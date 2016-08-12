using UnityEngine;
using UnityEditor;
using System.Collections;

public class ObjectFactory {
	private readonly GameObject parentUnit;
	private readonly Transform parentUnitTransform;
	private readonly GameObject parentTile;
	private readonly Transform parentTileTransform;
	private readonly string pathToTileSprite;
	private readonly string pathToUnitSprite;
	private readonly string tileName;
	private readonly string unitName;
	public Vector2 fakePosition { get; set; }
	public Vector2 position { get; set; }

	public ObjectFactory() {
		position = new Vector2(0, 0);
		fakePosition = new Vector2 (0, 0);

		parentTile = new GameObject ("Tile Holder");
		parentTileTransform = parentTile.GetComponent<Transform> ();
		pathToTileSprite = "Assets/Sprites/floor.png";

		parentUnit = new GameObject ("Unit Holder");
		parentUnitTransform = parentUnit.GetComponent<Transform> ();
		pathToUnitSprite = "Assets/Sprites/Ephraim.png";

		tileName = "Tile";
		unitName = "Unit";
	}


	private GameObject createGameObject(string name, Transform parentTransform)
	{
		GameObject gO = new GameObject (name);
		gO.GetComponent<Transform>().position = position;
		FakeTransform fakeTransform = gO.AddComponent<FakeTransform> ();
		fakeTransform.position = fakePosition;
		gO.transform.SetParent (parentTransform);
		return gO;
	}

	public GameObject createTile()
	{
		GameObject tile = createGameObject (tileName, parentTileTransform);
		SpriteRenderer spriteRenderer = tile.AddComponent <SpriteRenderer>();
		spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath(pathToTileSprite, typeof(Sprite));
		tile.AddComponent<PolygonCollider2D>();
		return tile;
	}

	public GameObject createUnit()
	{
		GameObject unit = createGameObject(unitName, parentUnitTransform);
		unit.layer = 9;
		SpriteRenderer spriteRenderer = unit.AddComponent <SpriteRenderer>();
		spriteRenderer.sprite = (Sprite) AssetDatabase.LoadAssetAtPath(pathToUnitSprite, typeof(Sprite));
		spriteRenderer.sortingOrder = 1;
		unit.AddComponent<PolygonCollider2D>();
		unit.AddComponent<Race> ();
		unit.AddComponent<Job> ();
		unit.AddComponent<Input> ();
		return unit;
	}



}
