using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour {
	public Button startButton;
	public Button exitButton;
	public Button middleButton;
	public Button instructionsButton;

	// Use this for initialization
	void Start () {
		startButton = startButton.GetComponent<Button>();
		exitButton = exitButton.GetComponent<Button>();
		middleButton = middleButton.GetComponent<Button>();
		instructionsButton = instructionsButton.GetComponent<Button>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("Characterselect");
	}

	public void instructions()
	{
		SceneManager.LoadScene ("instructions");
	}

	public void MiddleButton()
	{
		SceneManager.LoadScene ("Yee");
	}

	public void ClickExit()
	{
		Application.Quit ();
	}


}
