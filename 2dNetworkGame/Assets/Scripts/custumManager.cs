using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class custumManager : NetworkManager {
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public int select;
    // Use this for initialization
    void Start () {
        select = GameObject.Find("StorgaeDontDestroy").GetComponent<DontDestroyStorage>().whichCharacter;
    }
	
	// Update is called once per frame
	void Update () {
		
	}





    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        print(select);
        if (select == 1)
        {
            GameObject player = (GameObject)Instantiate(Player1, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (select == 2)
        {
            GameObject player = (GameObject)Instantiate(Player2, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (select == 3)
        {
            GameObject player = (GameObject)Instantiate(Player3, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        if (select == 4)
        {
            GameObject player = (GameObject)Instantiate(Player4, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        else
        {
            print("Select=0 using select=3");
            GameObject player = (GameObject)Instantiate(Player3, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }

    }

	public void StartupHost()
	{
		SetPort();
		NetworkManager.singleton.StartHost();
	}

	public void JoinGame()
	{
		SetIPAdress ();
		SetPort ();
		NetworkManager.singleton.StartClient ();
	}

	void SetIPAdress()
	{
		string ipAdress = GameObject.Find ("InputFieldIPAdress").transform.Find ("Text").GetComponent<Text> ().text;
		NetworkManager.singleton.networkAddress = ipAdress;
	}

	void SetPort()
	{
		NetworkManager.singleton.networkPort = 7777;
	}


}
