using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SendoAttack : MonoBehaviour {

	private Sendo sendo;
    private Sword sword;
	private float timer;
	public GameObject sendotext;
	public GameObject[] enemies;
	public GameObject sendoParticle;

    void Start () {
		sendo = this.GetComponent<Sendo> ();
        sword = this.GetComponent<Sword>();
    }

	void Update () {
		SendoAtk ();
	}

	public void SendoAtk () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			sendotext.SetActive(false);
		}
		if (sword.detect_button_sendo && SendoRdy()) {
			SendoParticleSpawner ();
			sendo.clearSendo ();
		} else if (sword.detect_button_sendo) {
			timer = 1.0f;
			sendotext.SetActive(true);
		}
	}

	public bool SendoRdy() {
		if (sendo.currentImage == 20) {
			return true;
		} else {
			return false;
		}
	}
	public void KillAllEnemies() {
		enemies = GameObject.FindGameObjectsWithTag ("enemy");

		for(var i = 0 ; i < enemies.Length ; i ++)
		{
			Destroy(enemies[i]);
		}
	}
	public void SendoParticleSpawner () {
		enemies = GameObject.FindGameObjectsWithTag ("enemy");
		for(var i = 0 ; i < enemies.Length ; i ++) {
			GameObject obj = Instantiate (sendoParticle, this.transform.position, Quaternion.identity) as GameObject;
			obj.GetComponent<SendoMover> ().target = enemies [i];
		}
	}
}
