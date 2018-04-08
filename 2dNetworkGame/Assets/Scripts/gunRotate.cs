using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class gunRotate : NetworkBehaviour {

	// Use this for initialization
	float scaleX;
	float scaleY;
	float angle;
	Vector3 mousePos;
	Vector3 objectPos;
	void Start () { 
		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (!transform.parent.gameObject.GetComponent<PlayerMove> ().isLocalPlayer) {
			
			return;
		}
			
		//print ("Rotate");
		mousePos= Input.mousePosition;
		//mousePos.z = 10; camera Z?
		objectPos=Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;

		//Ta Daaa

		if (transform.parent.gameObject.GetComponent<PlayerMove> ().getFacingR ()) {
			transform.localScale = new Vector3 (scaleX, scaleY, transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (-scaleX,-scaleY, transform.localScale.z);
		}

		transform.rotation =  Quaternion.Euler (new Vector3(0,0,angle));

	}

}
