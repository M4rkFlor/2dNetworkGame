using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerChooser : NetworkBehaviour {
	int select;
	// Use this for initialization
	void Start () {
		select = GameObject.Find ("StorgaeDontDestroy").GetComponent<DontDestroyStorage>().whichCharacter;
        print("Arean Select is" + select);
        spawn(select);
	}

	// Update is called once per frame
	void Update () {

	}

	
	void spawn(int sel)
	{
      
        if (sel == 1)
		{
			
		}
		if (sel == 2)
		{

		}
		if (sel == 3)
		{

		}
		if (sel == 4)
		{

		}
	}

   
}