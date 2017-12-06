using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioner : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		//Check for a match with the specified name on any GameObject that collides with your GameObject
		if (collision.gameObject.name == "Chara_4Hero")
		{
			//If the GameObject's name matches the one you suggest, output this message in the console
			Debug.Log("Collision With Chara");
			//ScriptFollowGirl.enabled = true;
		}

		//Check for a match with the specific tag on any GameObject that collides with your GameObject
		if (collision.gameObject.tag == "Chara_4Hero")
		{
			//If the GameObject has the same tag as specified, output this message in the console
			Debug.Log("Collision With Chara");
			//ScriptFollowGirl.enabled = true;
		}

		Debug.Log("Collision");
	}
}
