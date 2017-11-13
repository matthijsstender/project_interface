using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu_script : MonoBehaviour {

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject optiesmenu;
    [SerializeField] private GameObject creditsmenu;
    [SerializeField] private GameObject controlsmenu;

    private bool opties_active = true;
    private bool credits_active = true;
    private bool controls_active = true;

    // Update is called once per frame
    void Update () {
        
    }

    public void StartButton() {
        //switching to the scene of the game
        SceneManager.LoadSceneAsync("Project", LoadSceneMode.Single);
    }

    public void QuitButton() {
        //Quits game
        Application.Quit();
    }

    public void OptiesButton() {
        if(opties_active == true) {
            //Set the main menu on unactive and options in active
            menu.SetActive(false);
            optiesmenu.SetActive(true);

            opties_active = false;
        } else {
            //Set the options on unactive and main menu in active
            menu.SetActive(true);
            optiesmenu.SetActive(false);

            opties_active = true;
        }
        
    }
    public void ControlsButton()
    {
        if (controls_active == true)
        {
            //Set the main menu on unactive and controls in active
            menu.SetActive(false);
            controlsmenu.SetActive(true);

            controls_active = false;
        }
        else
        {
            //Set the controls on unactive and main menu in active
            menu.SetActive(true);
            controlsmenu.SetActive(false);

            controls_active = true;
        }

    }

    public void CreditsButton() {
        if (credits_active == true) {
            //Set the main menu on unactive and credits in active
            menu.SetActive(false);
            creditsmenu.SetActive(true);

            credits_active = false;
        } else {
            //Set the credits on unactive and main menu in active
            menu.SetActive(true);
            creditsmenu.SetActive(false);

            credits_active = true;
        }
    }

    public void BackToMenu() {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
    }
}
