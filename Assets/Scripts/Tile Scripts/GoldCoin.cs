using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    private FlowController flow;
    // Use this for initialization
    void Start()
    {
        FlowController sceneFlowController = FindObjectOfType<FlowController>();
        flow = sceneFlowController;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        flow.IncreaseCoinCount();
        Destroy(gameObject);
    }

    public void SetFlowController(FlowController flow)
    {
        this.flow = flow;
    }
}
