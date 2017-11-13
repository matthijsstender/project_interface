using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Sendo : MonoBehaviour {
	
	public Image[] images;
	public int currentImage = 0;

	void Start() {
		refreshImages();
	}

	void Update() {
	}

	public void addSendo(){
		if (currentImage != 20) {
			currentImage++;
			refreshImages();
		}
	}

	public void removeSendo(){
		if(currentImage <= 0){
			return;
		}
		currentImage--;
		refreshImages();
	}

	public void clearSendo(){
		currentImage = 0;
		refreshImages();
	}

	public bool fullSendo() {
		if (currentImage >= images.Length) {
			return true;
		} else {
			return false;
		}
	}

	private void refreshImages(){
		for (int i = 0; i < images.Length; i++) {
			images[i].color = Color.grey;
		}
		for (int i = 0; i < currentImage; i++) {
			images[i].color = Color.white;
		}
	}

}