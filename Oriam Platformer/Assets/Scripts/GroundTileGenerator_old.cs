/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileGenerator_old : MonoBehaviour {

	//public Dictionary<string, GameObject> tiles = new Dictionary<string, GameObject>();
	public GroundTileTemplate[] tileTemplates;

	protected bool[,] GroundTileMapArray; // GroundTileMapArray will hold all position values at 1 greater than they actually are.
	private int largestX;
	private int largestY;

	public void DefineGroundTileMapArray(int x, int y) {
		GroundTileMapArray = new bool[x , y];
	}

	public void AddTilePosition(GameObject template) {
		var position = template.transform.position;
		int x = (int)position.x;
		int y = (int)position.y;
		GroundTileMapArray[x, y] = true;
		if (x > largestX)
			largestX = x;
		if (y > largestY)
			largestY = y;
		
		Object.Destroy(template);


	}

	private void Awake() {
		LevelGenerator.OnLevelLoad += GenerateAllGroundTiles;
	}

	public void GenerateAllGroundTiles() {
		//GroundTileMapArray.Initialize();

		// Loop through GroudTileMapArray and GenerateGroundTile() where needed.
		for (int x = 0; x < largestX; x++) {
			for (int y = 0; y < largestY; y++) {
				if (GroundTileMapArray[x, y]) {
					GenerateGroundTile(x, y);

					//Make(x, y, tileTemplates[0].prefab);
				}
			}
		}

	}

	public void GenerateGroundTile(int x, int y) {
		// Here we now know that the entire GroundTileMapArray has been initialized.
		// We can now figure out the surroundings of the tile
		var t = new TileSurroundings();

		//debug statements


		// Begin checking proximity values
		if (GroundTileMapArray[x, y + 1])
			t.up = true;

		if (GroundTileMapArray[x + 1, y])
			t.right = true;

		if (GroundTileMapArray[x, y - 1])
			t.down = true;

		if (GroundTileMapArray[x - 1, y])
			t.left = true;

		//-Diagonals
		if (GroundTileMapArray[x + 1, y + 1])
			t.upright = true;

		if (GroundTileMapArray[x + 1, y - 1])
			t.downright = true;

		if (GroundTileMapArray[x - 1, y - 1])
			t.downleft = true;

		if (GroundTileMapArray[x - 1, y + 1])
			t.upleft = true;


		// Done checking proximity values, now check scenarios for possible sprites to take on

		if (t.up) {
			Make(x, y, GetTilePrefab("Dirt"));
		}
		else if (t.right && t.left) {
			Make(x, y, GetTilePrefab("Mid"));
		}
		else if (t.right) { // This is a Left Tile
			if (t.down)
				Make(x, y, GetTilePrefab("TopLeft"));
			else
				Make(x, y, GetTilePrefab("Left"));
		}
		else if (t.left) { // This is a Right Tile
			if (t.down)
				Make(x, y, GetTilePrefab("TopRight"));
			else
				Make(x, y, GetTilePrefab("Right"));
		}
		
		else {
			Make(x, y, GetTilePrefab("Solo"));
		}


		//Debugging
		if ((x == 24 || x == 25) && y == 10) {
			Debug.Log("Tile at " + x + ", " + y + "has the following values: " );
			t.PrintValues();
	
		}


	}

	void Make(int x, int y, GameObject prefab) {
		Instantiate(prefab, new Vector3(x , y , 0), Quaternion.identity, transform);
	}

	private GameObject GetTilePrefab(string name) {
		foreach (GroundTileTemplate t in tileTemplates) {
			if (t.name == name)
				return t.prefab;
		}
		return null;
	}

}

[System.Serializable]
public struct TileSurroundings {
	public bool up;
	public bool down;
	public bool left;
	public bool right;
	public bool upleft;
	public bool upright;
	public bool downleft;
	public bool downright;

	public void PrintValues() {
		Debug.Log("Up: " + up.ToString());
		Debug.Log("Down: " + down.ToString());
		Debug.Log("Left: " + left.ToString());
		Debug.Log("Right: " + right.ToString());
	}

}

[System.Serializable]
public class GroundTileTemplate {
	public string name;
	public GameObject prefab;
}

*/