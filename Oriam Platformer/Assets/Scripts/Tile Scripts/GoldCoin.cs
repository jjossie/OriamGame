using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    //public GameObject FlowControllerGameObject;
    private FlowController flow;
    // Use this for initialization
    void Start()
    {
        FlowController sceneFlowController = FindObjectOfType<FlowController>();
        //FlowControllerGameObject = sceneFlowController.gameObject;
        flow = sceneFlowController;
        //Debug.Log("Gold Coin Created");
        //Debug.Log("FlowControllerGameObject: " + FlowControllerGameObject.name);
        //Debug.Log("flow: " + flow.name);
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
