using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour {
	public GameObject FlowControllerGameObject;
	private FlowController flow;
	// Use this for initialization
	void Start() {

	}

	private void OnCollisionEnter2D(Collision2D collision) {
		flow.IncreaseCoinCount();
		Destroy(gameObject);
	}
}
