using UnityEngine;
using System.Collections;
/// <summary>
/// Defines the proximal location values for a ground tile. Surrounding tiles. To be used quickly and destroyed within a specific instance of a ground tile's creation.
/// </summary>

[System.Serializable]
public struct TileSurroundings
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool upleft;
    public bool upright;
    public bool downleft;
    public bool downright;

    public void PrintValues()
    {
        Debug.Log("Up: " + up.ToString());
        Debug.Log("Down: " + down.ToString());
        Debug.Log("Left: " + left.ToString());
        Debug.Log("Right: " + right.ToString());
    }

}