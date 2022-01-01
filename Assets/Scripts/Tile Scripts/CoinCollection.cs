using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private FlowController sceneFlowController;
    private List<GoldCoin> goldCoins = new();

    private void Awake()
    {
        sceneFlowController = FindObjectOfType<FlowController>();
        foreach (var coin in GetComponentsInChildren<GoldCoin>())
        {
            goldCoins.Add(coin);
        }
    }
    public void AddCoin(GoldCoin c)
    {
        goldCoins.Add(c);
    }

    public void RemoveCoin(GoldCoin c)
    {
        goldCoins.Remove(c);
        if (goldCoins.Count == 0)
        {
            sceneFlowController.Victory();
        }
    }
}
