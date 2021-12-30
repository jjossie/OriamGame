using UnityEngine;
/// <summary>
/// Defines an association between a color (to be found within a tilemap image) and a tile prefab
/// </summary>

[System.Serializable]
public class TileAssociation
{
    public Color color;
    public GameObject prefab;

    public TileAssociation()
    {
        color = Color.black;
        prefab = null;
    }
}

