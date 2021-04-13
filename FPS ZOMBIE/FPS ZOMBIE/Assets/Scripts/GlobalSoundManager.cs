using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour {

	public AudioSource music;
	//მუსიკის დაწყება
	public void PlayMusic(AudioClip clip) {
		music.clip = clip;
		music.Play();
	}
	//მუსიკის გაჩერება
	public void StopMusic() {
		music.Stop();
	}

	public void Play(AudioClip clip) {
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();

		audioSource.clip = clip;
		audioSource.Play();

		StartCoroutine(RemoveSoundComponent(audioSource));
	}

	IEnumerator RemoveSoundComponent(AudioSource audioSource) {
		yield return new WaitForSeconds(audioSource.clip.length);
		Destroy(audioSource);
	}

}
