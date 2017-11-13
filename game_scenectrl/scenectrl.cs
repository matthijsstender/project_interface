using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenectrl : MonoBehaviour {

    [SerializeField] private GameObject end_screen;
    [SerializeField] private GameObject game_screen;

    public Player player;
    public SendoAttack sendo;

    // Use this for initialization
    void Start () {

        player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        scene_swapper();
	}

    public void scene_swapper() {

        if(player.isDead == false) {

            end_screen.SetActive(true);
            sendo.KillAllEnemies();
            game_screen.SetActive(false);
        }
    }
}
