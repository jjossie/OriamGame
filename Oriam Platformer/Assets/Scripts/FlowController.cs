using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{

    public int coinCount;

    public void IncreaseCoinCount()
    {
        coinCount++;
        Debug.Log("Coins: " + coinCount);
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void SetCoinCount(int x)
    {
        coinCount = x;
    }
}
