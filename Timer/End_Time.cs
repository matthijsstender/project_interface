using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End_Time : MonoBehaviour {

    public Text endTimerText;
    public Player player;

    // Use this for initialization
    void Start () {

        //endTimerText = GetComponent<Text>();
        player.GetComponent<Player>();
        endTimerText.text = player.endTimer.ToString("f0");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
