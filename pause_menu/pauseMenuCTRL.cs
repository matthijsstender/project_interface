using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenuCTRL : MonoBehaviour {
    public Transform canvas;
    public Transform Player;

    public Button restartbutton;
    public Button resumbutton;
    public Button quitbutton;

    void Start() {
        restartbutton.onClick.AddListener(Restart);
        resumbutton.onClick.AddListener(Resume);
        quitbutton.onClick.AddListener(Quit);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }
    public void Pause() {
        if (canvas.gameObject.activeInHierarchy == false) {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;

        } else {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Restart() {
        SceneManager.LoadSceneAsync("Project", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Resume() {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit() {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
