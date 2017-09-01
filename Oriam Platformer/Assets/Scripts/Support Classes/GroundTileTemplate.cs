using UnityEngine;
/// <summary>
/// Defines a relationship between a string "name" and a proximity/location-based tile sprite (in the form of a prefab).
/// </summary>
[System.Serializable]
public class GroundTileTemplate {
	public string name;
	public GameObject prefab;
}