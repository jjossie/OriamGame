using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to be attatched to a "Level" gameobject that generates all level tiles. All tiles/gameobjects generated here are set as children of this gameobject.
/// </summary>

public class LevelGenerator : MonoBehaviour {

	public List<GroundTile> GroundTiles;
	public GroundTileTemplate[] tileTemplates;

	public void AddGroundTile(GroundTile g) {
		GroundTiles.Add(g);
	}
	public List<GroundTile> GetGroundTiles() {
		return GroundTiles;
	}

	private bool DoneGeneratingGroundTiles = false;
	private int GroundTileCount; // <-- This is a dumb fix. I can't figure out the sequencing, so I'm forcing the function to wait.

	public void GenerateAllGroundTiles() {
		DoneGeneratingGroundTiles = true;
		foreach (GroundTile tile in GroundTiles) {
			tile.GenerateGroundTile();
		}
	}

	// Relative Positioning Methods
	public GameObject GetTilePrefab(string name) {
		foreach (GroundTileTemplate t in tileTemplates) {
			if (t.name == name)
				return t.prefab;
		}
		return null;
	}
	public TileSurroundings GetSurroundings(int x, int y) {
		var t = new TileSurroundings();

		if (CheckProximity(x, y + 1))
			t.up = true;
		if (CheckProximity(x, y - 1))
			t.down = true;
		if (CheckProximity(x + 1, y))
			t.right = true;
		if (CheckProximity(x - 1, y))
			t.left = true;
		if (CheckProximity(x + 1, y + 1))
			t.upright = true;
		if (CheckProximity(x - 1, y - 1))
			t.downleft = true;
		if (CheckProximity(x + 1, y - 1))
			t.downright = true;
		if (CheckProximity(x - 1, y + 1))
			t.upleft = true;

		return t;
	}
	public bool CheckProximity(int x, int y) {
		foreach (GroundTile tile in GroundTiles) {
			if (tile.xPos == x && tile.yPos == y) {
				return true;
			}
		}
		return false;
	}


	public Texture2D mapImage;
	public List<TileAssociation> tileAssociations;

	public void AddTileAssociation() {
		
		tileAssociations.Add(new TileAssociation());
	}
	public void RemoveTileAssociation(TileAssociation t) {
		tileAssociations.Remove(t);
	}
	
	void Awake() { // Use this for initialization
		GroundTiles = new List<GroundTile>();
		GenerateLevel();
	}


	void GenerateLevel() {
		// Loop through each pixel
		for (int x = 0; x < mapImage.width; x++) {
			for (int y = 0; y < mapImage.height; y++) {
				Color currentPixelColor = mapImage.GetPixel(x, y); //Get the color
				GenerateTile(x, y, currentPixelColor); //Pass color into GenerateTile function
			}
		}
	}

	void GenerateTile(int x, int y, Color color) {
		if (color.a == 0)
			return; // Automatically void all empty pixels
		foreach (TileAssociation tile in tileAssociations) {
			if (color.Equals(tile.color)) {
				Vector2 newPosition = new Vector2(x, y);
				Instantiate(tile.prefab, newPosition, Quaternion.identity, transform);
				if (tile.prefab.CompareTag("GroundTiles")) {
					GroundTileCount++;
				}
			}
			if (color.Equals(tileAssociations[3].color)) {
			}
		}
		
	}

	private void Update() {
		if(!DoneGeneratingGroundTiles && (GroundTiles.Count == GroundTileCount)) {
			GenerateAllGroundTiles(); // <-- This is that dumb fix I was talking about earlier
			return;
		}
	}

}
