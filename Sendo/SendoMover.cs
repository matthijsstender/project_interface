using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendoMover : MonoBehaviour {
	public GameObject target;
	public float speed;

	// Use this for initialization
	void Start () {
		speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			float step = speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards (this.transform.position, target.transform.position, step);
			this.transform.rotation = Random.rotation;
		}

		if (Vector3.Distance(this.transform.position,target.transform.position) < 0.7f) {
			Destroy (target);
			Destroy (this.gameObject);
		}
	}
}
