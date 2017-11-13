using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPooper : MonoBehaviour {

	float timer;

	// Use this for initialization
	void Start () {
		timer = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Destroy (this.gameObject);
		}
	}
}
