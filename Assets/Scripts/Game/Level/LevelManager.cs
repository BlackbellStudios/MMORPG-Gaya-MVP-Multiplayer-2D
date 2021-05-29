using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.U2D;

public class LevelManager : MonoBehaviour {

	[SerializeField] private Transform map;
	[SerializeField] private Texture2D[] mapData;
	[SerializeField] private MapElement[] mapElements;
	[SerializeField] private Sprite defaultTile;
	private Dictionary<Point, GameObject> sandTiles = new Dictionary<Point,GameObject> ();
	[SerializeField] private SpriteAtlas sandAtlas;


	private Vector3 WorldStartPos{
		get{ 
			return Camera.main.ScreenToWorldPoint (new Vector3(0,0));
		}
	}

	// Use this for initialization
	void Start () {
		GenerateMap ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void GenerateMap(){
		int height = mapData [0].height;
		int width = mapData [0].width;

		for (int i = 0; i < mapData.Length; i++)
		{
			for (int x = 0; x < mapData[i].width; x++) 
			{
				for (int y = 0; y < mapData[i].height; y++) {
					Color c = mapData [i].GetPixel (x, y);

					MapElement	newElement = Array.Find (mapElements, e => e.MyColor == c);

					if (newElement != null) {
						float xPos = WorldStartPos.x + (defaultTile.bounds.size.x * x);
						float yPos = WorldStartPos.y + (defaultTile.bounds.size.y * y);
						GameObject go = Instantiate (newElement.MyElementPrefab);
						go.transform.position = new Vector2(xPos, yPos);

						if (newElement.MyTileTag == "Tree") {
							go.GetComponent<SpriteRenderer> ().sortingOrder = height*2 - y*2;
						}
							
						if (newElement.MyTileTag == "Sand") {
							sandTiles.Add (new Point(x,y), go);
						}

						go.transform.parent = map;
					}
				}
			}
		}
		CheckSand ();
	}

	private void CheckSand(){
		foreach (KeyValuePair<Point,GameObject> tile in sandTiles) {
			string composition = TileCheck (tile.Key);

			//PONTAS
			if (composition[1] == 'E' && composition[3] == 'S' && composition[4] == 'E' && composition[6] == 'S' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand000");
			}
			if (composition[1] == 'S' && composition[3] == 'S' && composition[4] == 'E' && composition[6] == 'E' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand002");
			}
			if (composition[1] == 'S' && composition[3] == 'E' && composition[4] == 'S' && composition[6] == 'E' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand008");
			}
			if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'S' && composition[6] == 'S' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand006");
			}

			//lATERAIS
			if (composition[1] == 'S' && composition[3] == 'S' && composition[4] == 'E' && composition[6] == 'S' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand001");
			}
			if (composition[1] == 'S' && composition[3] == 'E' && composition[4] == 'S' && composition[6] == 'S' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand007");
			}
			if (composition[1] == 'S' && composition[3] == 'S' && composition[4] == 'S' && composition[6] == 'E' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand005");
			}
			if (composition[1] == 'E' && composition[3] == 'S' && composition[4] == 'S' && composition[6] == 'S' ) {
				tile.Value.GetComponent<SpriteRenderer>().sprite = sandAtlas.GetSprite("Sand003");
			}
		}
	}

	private string TileCheck(Point currentPoint){
		string composition = string.Empty;
		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if (x!=0 || y!=0) {
					if (sandTiles.ContainsKey(new Point(currentPoint.MyX+x, currentPoint.MyY+y))) {
						composition += "S";
					} else {
						composition += "E";
					}
				}
			}
		}
		//Debug.Log (composition);
		return composition;
	}
}

[Serializable]
public class MapElement
{
	[SerializeField] private string tileTag;
	[SerializeField] private Color color;
	[SerializeField] private GameObject elementPrefab;

	public GameObject MyElementPrefab{
		get{ 
			return elementPrefab;
		}
	}
	public Color MyColor {
		get {
			return color;
		}
	}

	public string MyTileTag {
		get {
			return tileTag;
		}
	}
}

public struct Point
{
	public int MyX { get; set;}
	public int MyY { get; set;}

	public Point(int x, int y){
		this.MyX = x;
		this.MyY = y;
	}
}