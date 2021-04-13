using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMP45 : MonoBehaviour {
	[Header("Sounds")]
	public SoundManager soundManager;
	public AudioClip magOutSound;
	public AudioClip magInSound;
	public AudioClip boltSound;

	//ხმები გადატენვის,სროლის და ასეშემდეგ

	void OnDraw() {
		soundManager.Play(boltSound);
	}

	void OnMagOut() {
		soundManager.Play(magOutSound);
	}

	void OnMagIn() {
		soundManager.Play(magInSound);
	}

	void OnBoltPulled() {
		soundManager.Play(boltSound);
	}
}
