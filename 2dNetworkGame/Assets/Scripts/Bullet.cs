using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

	public AudioClip bam;

	// Use this for initialization
	void Start () {
		transform.Rotate (0,0,-90);
	}
	
	// Update is called once per frame
	void Update () {


		
	}


	void OnCollisionEnter(Collision collision)
	{
		//if (collision.gameObject.tag == "bounce") {
		//	if (transform.position.y < collision.collider.bounds.min.y) {
		//		transform.eulerAngles = new Vector3 (0, 0, 180.0f - transform.eulerAngles.z);
		//	}
		//}
		if (collision.gameObject.tag != "Player") {
			Destroy (gameObject);
		}

        else
        {
			if (!isLocalPlayer) {
				var hit = collision.gameObject;
				var health = hit.GetComponent<Health> ();

				if (health != null) {
					health.takeDamage (5);
					transform.Translate (500, 0, 0);
					//transform.localScale = new Vector3 (.001f, .001f, .001f);
					//Destroy (gameObject);
				}

		    }
			
		}
		playSound (bam);

	}

	public void playSound(AudioClip soundName) {
		AudioSource audio = GetComponent<AudioSource> ();
		if (!audio.isPlaying || audio.clip != soundName) {
			audio.clip = soundName;
			audio.Play ();
		}
	}
}
