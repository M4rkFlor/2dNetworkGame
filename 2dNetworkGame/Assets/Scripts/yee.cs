using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yee : MonoBehaviour {
	public Button ButtonBack;
	// Use this for initialization
	void Start () {
		ButtonBack = ButtonBack.GetComponent<Button>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void back()
	{
		print ("test");
		SceneManager.LoadScene ("start menu");
	}


}
