using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;  //Target  position
	public float smoothing = 2f; // Camera speed;

	private float yaw = 0.0f;
	private float pitch = 0.0f;


	Vector3 offset;

	void Start(){
		target = GameObject.Find("MaleFree1").transform;
		offset = transform.position - target.position;
	}

	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

		transform.LookAt (target);


		yaw += smoothing * Input.GetAxis ("Mouse X");
		pitch -= smoothing * Input.GetAxis ("Mouse Y");

		transform.eulerAngles = new Vector3 (pitch, yaw, 0f);


		Debug.Log (transform.rotation);
	
	}



}
