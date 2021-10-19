using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGroundTileConstructor : MonoBehaviour {

	// Use this for initialization
	void Start() {
		new GroundTile((int)transform.position.x, (int)transform.position.y);
		GameObject.Destroy(this.gameObject);
	}

}
