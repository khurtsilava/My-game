using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	//მტრის ხმები
	public AudioClip attackSound; //შეტევის ხმა
	public AudioClip deathSound; //მოკვლის ხმა

	public Material deadMaterial;
	private Animator animator;
	private AudioSource audioSource;
	private Chasing chasing;
	private HealthManager healthManager;
	private bool wasAlreadyDead = false;

	void Start() {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		chasing = GetComponent<Chasing>();
		healthManager = GetComponent<HealthManager>();
	}

	void Update() {
		if(wasAlreadyDead == true) return;

		// Stop chasing and set dead if it's dead
		//შეწყვეტა დევნა და მკვდარზე დაყენება თუ ის მკვდარია
		if(!wasAlreadyDead && healthManager.IsDead) {
			wasAlreadyDead = true;

			SetDead();
			chasing.StopChasing();
		}
	}
	
	void SetDead() {
		RemoveColliders(GetComponents<Collider>());
		RemoveColliders(GetComponentsInChildren<Collider>());

		animator.SetTrigger("Dead");
		audioSource.PlayOneShot(deathSound);

		transform.Find("Icon").GetComponent<MeshRenderer>().material = deadMaterial;
		
		Destroy(gameObject, 5f);
	}

	void RemoveColliders(Collider[] colliders) {
		foreach(Collider collider in colliders) {
			collider.enabled = false;
		}
	}

	//შეტევა და შეტევის ხმა 
	public void PlayAttackAnimation() {
		animator.SetTrigger("Attack");
		audioSource.PlayOneShot(attackSound);
	}
}
