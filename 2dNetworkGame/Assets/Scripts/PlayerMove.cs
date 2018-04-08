using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour {
	//
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	//public Animator anim;
	Vector3 velocity = Vector3.zero;
	//public Animator anim;
	float gravity = 20.0f;
	float BulletSpeed = 15.0f;
	bool LookRight;
	float speed;
	float scale;
	bool DoubleJump;
	public int character;

	public Sprite InternetExplorer;
	public Sprite firefox;
	public Sprite unity;
	public Sprite minecraft;

	[SyncVar]
	private int syncCharVal;
	[SerializeField]
	int myCharacterVal;



	// Use this for initialization
	public override void OnStartLocalPlayer() {
		
		scale = transform.localScale.x;
		Camera.main.transform.parent = this.transform;
		speed = 1.0f;
		//anim = this.GetComponent<Animator>();
		character = GameObject.Find("StorgaeDontDestroy").GetComponent<DontDestroyStorage>().whichCharacter;
		myCharacterVal = character;
		print (character);

		if (character == 2) {
			gameObject.GetComponent<SpriteRenderer>().sprite = minecraft;
		}
		if (character == 3) {
			gameObject.GetComponent<SpriteRenderer>().sprite = firefox;
		}
		if (character == 4) {
			gameObject.GetComponent<SpriteRenderer>().sprite = unity;
		}

	}
	/// <summary>
	void FixedUpdate()
	{
		TransmitSprite();
		ReciveSprite();

	}

	[ClientCallback]
	void TransmitSprite()
	{
		if (isLocalPlayer)
		{
			CmdProvideSpriteToSever(myCharacterVal);
		}

	}

	void ReciveSprite()
	{
		if (!isLocalPlayer)
		{
			myCharacterVal= syncCharVal;
			if (myCharacterVal == 1) {
				gameObject.GetComponent<SpriteRenderer>().sprite = InternetExplorer;
			}
			if (myCharacterVal == 2) {
				gameObject.GetComponent<SpriteRenderer>().sprite = minecraft;
			}
			if (myCharacterVal == 3) {
				gameObject.GetComponent<SpriteRenderer>().sprite = firefox;
			}
			if (myCharacterVal == 4) {
				gameObject.GetComponent<SpriteRenderer>().sprite = unity;
			}
		}
	}


	[Command]
	void CmdProvideSpriteToSever(int _charval)
	{
		syncCharVal = _charval;
	}



	/// </summary>

	// Update is called once per frame
	void Update ()
	{
		if (!isLocalPlayer)
			return;


		if (Input.GetMouseButtonDown(0))
		{
			CmdFire();
		}
		if (Input.mousePosition.x > Screen.width / 2) {
			transform.localScale = new Vector3 (scale, transform.localScale.y, transform.localScale.z);
			LookRight = true;
		} 
		else
		{
			transform.localScale = new Vector3 (-scale, transform.localScale.y, transform.localScale.z);
			LookRight = false;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		//print (Input.mousePosition);



		// float x = Input.GetAxis ("Horizontal") * 2.5f*Time.deltaTime;

		//float y = Input.GetAxis ("Vertical") * 2.5f*Time.deltaTime;

		//transform.position += new Vector3 (x, y, 0);
		/////////////////////////////////////////
		CharacterController controller = GetComponent<CharacterController> ();





		//makes sure that player is on an object.
		velocity = new Vector3(Input.GetAxis("Horizontal") * speed, velocity.y, 0);
		if(controller.isGrounded)
			DoubleJump = false;
		if (Input.GetKeyDown ("space"))
		{
			if(!DoubleJump)
				velocity.y = 10.5f;
			if (!controller.isGrounded)
				DoubleJump = true;



		} else if (Input.GetKey ("left") || Input.GetKey ("a"))
		{
			speed = 10f;
			/*anim.SetFloat ("Speed", -10);
			if (LookRight)
				anim.SetBool ("WalkBackwards", true);
			else
				anim.SetBool ("WalkBackwards", false);*/
		} 
		else if (Input.GetKey ("right") || Input.GetKey ("d"))
		{
			speed = 10f;
			/*anim.SetFloat ("Speed", 10);
			if (!LookRight)
				anim.SetBool ("WalkBackwards", true);
			else
				anim.SetBool ("WalkBackwards", false);*/
		} 
		else
		{
			speed = 1;
			//anim.SetFloat ("Speed", 0);
			//anim.SetBool ("WalkBackwards", false);
		}
			

		if (!controller.isGrounded)
		{
			velocity.y -= gravity * Time.deltaTime;//apply gravity
		}
		controller.Move (velocity * Time.deltaTime);  //move the controller

	}

	public bool getFacingR(){
		return LookRight;
	}

	void OnControllerColliderHit(ControllerColliderHit collision)
	{
		//print ("here");
		if (transform.position.y < collision.collider.bounds.min.y) {
			if(velocity.y >=0)
			velocity.y = -2;
			//print ("here");
	}



		
	}


	[Command]
	void CmdFire()
	{


		
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * BulletSpeed;

		// Spawn the bullet on the Clients
		NetworkServer.Spawn(bullet);


		// Destroy the bullet after 2 seconds
		Destroy(bullet, 5.0f);
	}


}