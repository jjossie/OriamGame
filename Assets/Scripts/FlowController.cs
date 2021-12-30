using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{

    public int coinCount;
    public int totalCoinCount;

    public void IncreaseCoinCount()
    {
        coinCount++;
        Debug.Log("Coins: " + coinCount);
        if (coinCount == totalCoinCount)
        {
            Victory();
        }
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void SetCoinCount(int x)
    {
        coinCount = x;
    }

    public void SetTotalCoinCount(int count)
    {
        totalCoinCount = count;
    }

    public int GetTotalCoinCount()
    {
        return totalCoinCount;
    }

    public void AddCoinToTotal()
    {
        totalCoinCount++;
    }

    private void Victory()
    {
        Debug.Log("Objective Complete!");
    }
}
