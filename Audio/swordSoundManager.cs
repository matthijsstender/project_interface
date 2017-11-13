using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class swordSoundManager : MonoBehaviour {

	public AudioClip[] clips;
	public AudioMixerGroup output;

	public void PlaySound() {
		int randomClip = Random.Range (0, clips.Length);
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = clips[randomClip];
		source.outputAudioMixerGroup = output;
		source.Play ();
		Destroy (source, clips [randomClip].length);
	}
}
