using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Characterselectmenu : MonoBehaviour {
	public Button internetexplorerButton;
	public Button minecraftButton;
	public Button firefoxButton;
	public Button unityButton;
	public Button selectButton;
	public int character;
    // Use this for initialization
    

    void Start () {
		internetexplorerButton = internetexplorerButton.GetComponent<Button>();
		minecraftButton = minecraftButton.GetComponent<Button>();
		firefoxButton = firefoxButton.GetComponent<Button>();
		unityButton = unityButton.GetComponent<Button>();
		selectButton = selectButton.GetComponent<Button>();
		character = 0;

	}
	
	// Update is called once per frame
	void Update () {
//        print(character);
	}

    //miadont
	//ftydytszgeb
	public void StartGame()
	{
        if(character!=0)
        SceneManager.LoadScene("Arena");
    }

	public void back()
	{
		SceneManager.LoadScene ("start menu");
	}

	public void internetexplorer()
	{
		character = 1;
	}

	public void minecraft()
	{
		character = 2;
	}

	public void firefox()
	{
		character = 3;
	}

	public void unity()
	{
		character = 4;
	}
}
