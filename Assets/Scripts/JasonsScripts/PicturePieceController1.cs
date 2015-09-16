using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PicturePieceController1 : MonoBehaviour {
	
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
				Debug.Log ("Up");
		
				// calculates the distance and returns a boolean
				if ((isOn == false) && isItClose ())   // are we close enough?  
		{renderer.enabled = false;
				On ();
		}
		else
			displaytt ("That shit is too far bruh.");
	}
	
	public void On() {

		displaytt ("It's a torn piece of a picture.");
		isOn = true ;
	}
	
	public bool isItClose() {
		float obXDistance = transform.position.x;  // lightswitch x
		float obYDistance = transform.position.y;  // lightswitch y
		
		// object distance              // Player distance
		// used abs value to get the ABS distance since fixed coordinate
		float distanceX = Mathf.Abs (obXDistance - Player.transform.position.x);
		float distanceY = Mathf.Abs (obYDistance - Player.transform.position.y);
		
		// final distance between objec and player
		float distance = Mathf.Sqrt ((distanceX*distanceX) + (distanceY *distanceY));  
		
		return  (gameDistance >= distance);  // are we close enough
	}
	
	public void displaytt(string speech) {
		msg.text = speech;
	}
	
}