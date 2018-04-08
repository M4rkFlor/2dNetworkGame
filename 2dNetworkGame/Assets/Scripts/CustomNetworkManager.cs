using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager {

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
