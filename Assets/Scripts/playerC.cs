using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerC : MonoBehaviour {
	public float speed = 5f;
	public float rotateSpeed = 3.0F;
	public float jumpSpeed = 13f;

	Vector3 movement;
	Animator  anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	public float smoothing = 5f; // Camera speed;

	public float moveSpeed;

	private bool jump;



	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		float z = Input.GetAxisRaw ("Jump");
		alternateMove (h, v);
		Turning ();
		Animating (h, v);
		Jump (z);
	}
		
	void Jump(float z){
		
			

		CharacterController cc = GetComponent<CharacterController> ();

		Vector3 forward = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward)*moveSpeed;
		transform.Rotate (new Vector3(0.0f, (Input.GetAxis ("Horizontal")*rotateSpeed*Time.deltaTime), 0.0f));

		cc.Move (forward * Time.deltaTime);
		cc.SimpleMove (Physics.gravity*Time.deltaTime);

		if (Input.GetButton("Jump"))
		{
			Vector3 jumpUp = transform.TransformDirection(Vector3.up)*jumpSpeed;
			cc.Move (jumpUp * Time.deltaTime);
			anim.SetBool ("IsJumping", true);
		}else if(Input.GetButton("Jump") != true && cc.isGrounded) {
			
				anim.SetBool ("IsJumping", false);

		}
	}

	void Move (float h, float v){
		
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);

		//Quaternion rotation = Quaternion.LookRotation (playerRigidbody.position);

	}

	void alternateMove(float h, float v){

		if (Input.GetButton("Run")){ speed = 10f;}
		CharacterController controller = GetComponent<CharacterController>();
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		float curSpeed = speed * Input.GetAxis("Vertical");
		controller.SimpleMove(forward * curSpeed);
		speed = 5f;

		//transform.position += transform.forward * Time.deltaTime * speed;			



	}

	void Turning(){

		yaw += smoothing * Input.GetAxis ("Mouse X");
		pitch -= smoothing * Input.GetAxis ("Mouse Y");

		transform.eulerAngles = new Vector3 (0f, yaw, 0f);



	}

	void Animating(float h, float v)
	{
		bool walking = h !=0f || v != 0f;

		Debug.Log (v);


		if(v == -1 ){anim.SetBool ("IsBackWalking", true); anim.SetBool ("IsWalking", false); Debug.Log ("back");}
		else{ anim.SetBool ("IsBackWalking", false); anim.SetBool("IsWalking", walking); }




	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
