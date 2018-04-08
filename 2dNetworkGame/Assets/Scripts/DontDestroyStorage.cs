using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyStorage : MonoBehaviour {





    public int whichCharacter;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	void Update () {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Characterselect")
        {
            whichCharacter = GameObject.FindObjectOfType<Characterselectmenu>().character;

		}

      
	}

}
