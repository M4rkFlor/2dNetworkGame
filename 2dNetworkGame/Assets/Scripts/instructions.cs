using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class instructions : MonoBehaviour {
	public Button backButton;
	// Use this for initialization
	void Start () {
		backButton = backButton.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void back()
	{
		SceneManager.LoadScene ("start menu");
	}


}
