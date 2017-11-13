using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;
using System.IO.Ports;
 


public class Sword : MonoBehaviour {
    
    public SerialPort stream;

    public int baudrate = 9600;

    public Animator swordAnimator;

	private Sendo sendo;
	private swordSoundManager audio;
    public swordCol swordcol1;
    public swordCol swordcol2;
    public swordCol swordcol3;

    public string port = "COM4";
    public string[] text;

    public bool detect_rotation_max;
    public bool detect_button_sendo;
    public bool detect_button_down;

    public bool beginTimer;
    public bool beginAnimationTimer;
    public int setActiveTimer = 100;
    public int animationTimer = 10;

    public Transform swordCol_1;
    public Transform swordCol_2;
    public Transform swordCol_3;


    void Start () {

		sendo = this.GetComponent<Sendo> ();

		audio = this.GetComponent<swordSoundManager> ();

        swordAnimator = gameObject.GetComponent<Animator>();

        stream = new SerialPort("COM4", 9600);
        stream.ReadTimeout = 50;
        stream.Open();

        detect_rotation_max = true;
        detect_button_sendo = false;
        detect_button_down = false;
        beginTimer = false;
    }
    void Update() {

        text = stream.ReadLine().Split(","[0]);

		CheckKeyboardSlash();
        CheckSlash();
        CheckButton();
        
        if(swordcol1.killed == true){
            sendo.addSendo();
            swordcol1.killed = false;
        }
        if (swordcol2.killed == true){
            sendo.addSendo();
            swordcol2.killed = false;
        }
        if (swordcol3.killed == true){
            sendo.addSendo();
            swordcol3.killed = false;
        }

        if(beginTimer == true){

            setActiveTimer--;
            if (setActiveTimer <= 0){
                beginTimer = false;
                setActiveTimer = 100;
            }
        }

        if(beginAnimationTimer == true){

            animationTimer--;
            if(animationTimer <= 0){
                beginAnimationTimer = false;
                animationTimer = 10;
            }
        }
    }

    private void CheckSlash() {

        int detect_slash = int.Parse(text[0]);
        //print(int.Parse(text[1]));
        int detect_rotation = int.Parse(text[1]);

        if (detect_rotation <= 20000) {
            detect_rotation_max = false;
        }else {
            detect_rotation_max = true;
        }
		if (detect_slash <= 9000 && detect_rotation <= -10000){

            //detect if its a normalslash
            print("Normalslash");
            swordCol_2.gameObject.SetActive(true);
            beginTimer = true;
            beginAnimationTimer = true;
            swordAnimator.SetBool("slash right", true);
		}else if (detect_slash <= 9000 && detect_rotation >= 8000)
        {

            //detect if its a reverseslash
            print("Reverseslash");
            swordCol_3.gameObject.SetActive(true);
            beginTimer = true;
            beginAnimationTimer = true;
            swordAnimator.SetBool("slash left", true);
        }
		else if (detect_slash >= 10000){

            //detect if its a downslash
			print("Overheadslash");
            swordCol_1.gameObject.SetActive(true);
            beginTimer = true;
            beginAnimationTimer = true;
            swordAnimator.SetBool("forward slash", true);
        }
        if(beginTimer == false){
            swordCol_1.gameObject.SetActive(false);
            swordCol_2.gameObject.SetActive(false);
            swordCol_3.gameObject.SetActive(false);
        }

        if (beginAnimationTimer == false){
            swordAnimator.SetBool("forward slash", false);
            swordAnimator.SetBool("slash left", false);
            swordAnimator.SetBool("slash right", false);
        }
    }

	private void CheckKeyboardSlash() {
		if(Input.GetKeyDown(KeyCode.D)) {
			//detect if its a normalslash
			print("Normalslash");
			audio.PlaySound ();
			swordCol_3.gameObject.SetActive(true);
			beginTimer = true;
            beginAnimationTimer = true;
            swordAnimator.SetBool("slash right", true);
		}else if(Input.GetKeyDown(KeyCode.A)) {
			//detect if its a reverseslash
			print("Reverseslash");
			audio.PlaySound ();
			swordCol_2.gameObject.SetActive(true);
			beginTimer = true;
            beginAnimationTimer = true;
            swordAnimator.SetBool("slash left", true);
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
			//detect if its a overheadslash
			print("Overheadslash");
			audio.PlaySound ();
			swordCol_1.gameObject.SetActive(true);
			beginTimer = true;
            beginAnimationTimer = true;
			swordAnimator.SetBool("forward slash", true);
        }

		if(beginTimer == false){
			swordCol_1.gameObject.SetActive(false);
			swordCol_2.gameObject.SetActive(false);
			swordCol_3.gameObject.SetActive(false);
		}

        if(beginAnimationTimer == false){
            swordAnimator.SetBool("forward slash", false);
            swordAnimator.SetBool("slash left", false);
            swordAnimator.SetBool("slash right", false);
        }
	}

    private void CheckButton(){

        int detect_sendo = int.Parse(text[2]);

        if (detect_sendo == 1)
        {
            detect_button_sendo = true;
        }
        else if (detect_sendo == 0)
        {
            detect_button_sendo = false;
        }
    }
}