using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Class to be instantiated for every MonoGroundTileConstructor prefab created in order to be indexed and controlled by LevelGenerator. 
/// </summary>

public class GroundTile
{

    public int xPos;
    public int yPos;
    private LevelGenerator level;
    //Instantial Methods

    // Construction

    public GroundTile(int x, int y)
    {
        xPos = x;
        yPos = y;
        level = GameObject.Find("Level").GetComponent<LevelGenerator>();
        level.AddGroundTile(this);
    }


    public void GenerateGroundTile()
    {
        // Begin checking proximity values to determine surroundings
        var t = level.GetSurroundings(xPos, yPos);
        // Done checking proximity values, now check scenarios for possible sprites to take on

        if (t.up)
        {
            Make(level.GetTilePrefab("Dirt"));
        }
        else if (t.right && t.left)
        {
            Make(level.GetTilePrefab("Mid"));

        }
        else if (t.right)
        { // This is a Left Tile
            if (t.down)
                Make(level.GetTilePrefab("TopLeft"));
            else
                Make(level.GetTilePrefab("Left"));
        }
        else if (t.left)
        { // This is a Right Tile
            if (t.down)
                Make(level.GetTilePrefab("TopRight"));
            else
                Make(level.GetTilePrefab("Right"));
        }

        else if (t.down)
        {
            Make(level.GetTilePrefab("TopMid"));
        }
        else
        {
            // DELETE ME BUT USE THE SAME CONCEPT IN A BETTER WAY LATER I GUESS
            if (t.upright && t.downleft)
            {
                Make(level.GetTilePrefab("SlopeRight"));
            }
            else if (t.upleft && t.downright)
            {
                Make(level.GetTilePrefab("SlopeLeft"));
            }
            else
            {
                Make(level.GetTilePrefab("Solo"));
            }

        }

    }

    private void Make(GameObject prefab)
    {
        //Instantiate(prefab, new Vector3(xPos, yPos, 0), Quaternion.identity, GameObject.Find("Level").transform);
        GameObject.Instantiate(prefab, new Vector3(xPos, yPos, 0), Quaternion.identity, GameObject.Find("Level").transform);
        // Add code to self-destroy this object instance here.
    }


    public override string ToString()
    {
        string output = "";

        output += "I am a ground tile at ";
        output += xPos;
        output += ", ";
        output += yPos;

        return output;
    }
}
