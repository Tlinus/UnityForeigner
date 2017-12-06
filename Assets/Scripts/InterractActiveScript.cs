using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractActiveScript : MonoBehaviour {

	public GameObject targetHero; 
	public GameObject targetHerona;
	private Behaviour ScriptFollowGirlHero;
	private Behaviour ScriptFollowGirlHerona;
	private GameObject ScriptFollow;
	private GameObject Text;
	private Behaviour TextContent;
	private int SomeoneFound;
	private bool HeroFound;
	private bool HeronaFound;

	// Use this for initialization
	void Start () {
		targetHero = GameObject.Find("Chara_4Hero");
		ScriptFollowGirlHero = targetHero.GetComponent("Follow") as Behaviour;

		targetHerona = GameObject.Find("Chara_4Herona");
		ScriptFollowGirlHerona = targetHerona.GetComponent("Follow") as Behaviour;

		SomeoneFound = 0; HeroFound = false; HeronaFound = false;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private IEnumerator DestroyText(GameObject Text){
		yield return new WaitForSeconds (17);
		Destroy (Text);

	}
	void OnTriggerEnter(Collider collision)
	{
		//Check for a match with the specified name on any GameObject that collides with your GameObject
		if (collision.gameObject.name == "Chara_4Hero" || collision.gameObject.tag == "Chara_4Hero") 
		{
			//If the GameObject's name matches the one you suggest, output this message in the console

			if (HeronaFound == false ) {
				Text = GameObject.Find ("FindSomeoneText1");

			} else {
				Text = GameObject.Find ("FindSomeoneText2");
			}

			HeroFound = true;	SomeoneFound++;
			Debug.Log("Collision With Chara");
			ScriptFollowGirlHero.enabled = true;

			TextContent = Text.GetComponent ("Text") as Behaviour;
			TextContent.enabled = true;
			StartCoroutine(DestroyText(Text));

		}

		if (collision.gameObject.name == "Chara_4Herona" || collision.gameObject.tag == "Chara_4Herona") {
			if (HeroFound == false  ) {
				Text = GameObject.Find ("FindSomeoneText1");

			} else {
				Text = GameObject.Find ("FindSomeoneText2");
			}
			HeronaFound = true;	SomeoneFound++;
			Debug.Log("Collision With Chara");
			ScriptFollowGirlHerona.enabled = true;

			TextContent = Text.GetComponent ("Text") as Behaviour;
			TextContent.enabled = true;
			StartCoroutine(DestroyText(Text));
		}


		if (collision.gameObject.name == "FinalDest" || collision.gameObject.tag == "FinalDest" || collision.gameObject.name == "FinalDest2" || collision.gameObject.tag == "FinalDest2") {
			if (HeroFound == true && HeronaFound == true) {
				Text = GameObject.Find ("ArrivedEnd");
				TextContent = Text.GetComponent ("Text") as Behaviour;
				TextContent.enabled = true;
				StartCoroutine(DestroyText(Text));
				ScriptFollowGirlHero.enabled = false;
				ScriptFollowGirlHerona.enabled = false;

				Destroy (collision.gameObject);
			}

		}

		if (collision.gameObject.name == "EndStart" || collision.gameObject.tag == "EndStart")
		{
			Text = GameObject.Find ("StarterText");
			Destroy (collision.gameObject);
			Destroy (Text);
		}

		if (collision.gameObject.name == "ExitCheckPoint" || collision.gameObject.tag == "ExitCheckPoint")
		{
			Text = GameObject.Find ("ExitText");
			Destroy (collision.gameObject);
			TextContent = Text.GetComponent ("Text") as Behaviour;
			TextContent.enabled = true;
		}

		if (collision.gameObject.name == "ExitCheckPoint2" || collision.gameObject.tag == "ExitCheckPoint2")
		{
			Destroy (collision.gameObject);
			TextContent.enabled = false;
		}


		Debug.Log("Collision");


	}
			
}
