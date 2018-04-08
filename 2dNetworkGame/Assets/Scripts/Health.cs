using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	float tTimmer;
	public AudioClip death;

	public const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;

	public RectTransform healthBar;

	public void takeDamage(int amount)
	{
		if (!isServer)
			return;

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
			GameObject.Find ("blueScreen").GetComponent<blueScreen>().moveCenter();
			playSound (death);
		}
	}
	void Update ()
	{
		tTimmer += Time.deltaTime;
		if (tTimmer > 3) {
			currentHealth += 10;
			tTimmer = 0;
			if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
	}

	void OnChangeHealth (int health)
	{
		healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
	}

	public void playSound(AudioClip soundName) {
		AudioSource audio = GetComponent<AudioSource> ();
		if (!audio.isPlaying || audio.clip != soundName) {
			audio.clip = soundName;
			audio.Play ();
		}
	}
}
