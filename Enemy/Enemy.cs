using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public Transform player;
    private float minD = 2f;
    public static float sTime = 2f;
    private Vector3 sVel = Vector3.zero;

    void Update()
    {
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(target);

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > minD)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target, ref sVel, sTime);
        }
    }

	void OnParticleCollision(GameObject other) {
		Destroy (this.gameObject);
	}

    public void SetsTime(float s)
    {
        sTime += s;
    }
}