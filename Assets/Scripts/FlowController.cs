using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{

    public int coinCount;
    public List<GoldCoin> goldCoins;

    //public void IncreaseCoinCount()
    //{
    //    coinCount++;
    //    Debug.Log("Coins: " + coinCount);
    //    if (coinCount == goldCoins.Count)
    //    {
    //        Victory();
    //    }
    //}

    public void Victory()
    {
        Debug.Log("Objective Complete!");
    }
}
