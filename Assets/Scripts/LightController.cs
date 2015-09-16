using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightController : MonoBehaviour {
	
	public bool isOn ;
	private GameObject Player ;
	public float gameDistance ;
	public bool isNear;
	Text msg;

	
	
	//public  msg ;
	
	void Start() {
		isOn = false ;
		isNear = false;
		Player = GameObject.FindGameObjectWithTag ("Player");
		msg = GameObject.FindGameObjectWithTag ("Message").GetComponent<Text> ();
	}
	
	public void OnMouseEnter() {
		Debug.Log("Enter") ;
	}
	
	public void OnMouseExit() {
		Debug.Log("Exit") ;
	}
	
	public void OnMouseUp() {
		Debug.Log("Up") ;
		
		// calculates the distance and returns a boolean
		if ((isOn == false) && isItClose ())   // are we close enough?  
			On ();
		  else
		            displaytt ("I can't reach that");
	}
	
	public void On() {
		animation.Play("turnOn") ;
		displaytt ("Good.");
		isOn = true ;
	}
	
	public bool isItClose() {
		float obXDistance = transform.position.x;  // lightswitch x
		float obYDistance = transform.position.y;  // lightswitch y
		
		// object distance              // Player distance
		// used abs value to get the ABS distance since fixed coordinate
		float distanceX = Mathf.Abs (Mathf.Abs (obXDistance) - Mathf.Abs (Player.transform.position.x));
		float distanceY = Mathf.Abs (Mathf.Abs (obYDistance) - Mathf.Abs (Player.transform.position.y));
		
		// final distance between objec and player
		float distance = Mathf.Sqrt ((distanceX*distanceX) + (distanceY *distanceY));  
		
		return  (gameDistance >= distance);  // are we close enough
	}
	
	public void displaytt(string speech) {
	      msg.text = speech;
	}
	
}