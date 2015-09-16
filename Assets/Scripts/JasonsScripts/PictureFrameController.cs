using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PictureFrameController : MonoBehaviour {
	


	Text msg;
	
	
	
	//public  msg ;
	
	void Start() {

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
		
	 
			displaytt ("It's an empty picture frame. I wonder what was in it?");
	}


	
	public void displaytt(string speech) {
		msg.text = speech;
	}
	
}