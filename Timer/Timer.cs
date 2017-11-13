using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text blackTimerText;
    public Text whiteTimerText;
    public float myTimer;

    void Start()
    {
    }

    void Update()
    {
        myTimer += Time.deltaTime;
        blackTimerText.text = myTimer.ToString("f0");
        whiteTimerText.text = myTimer.ToString("f0");
    }
}
