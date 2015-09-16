using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerScene1 : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.15f;
	public LayerMask whatIsGround;
	public float jumpForce = 5f;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 ( move * maxSpeed, rigidbody2D.velocity.y);
		anim.SetFloat ("Speed" ,Mathf.Abs(move));

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}

	void Update() {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce( new Vector2(0, jumpForce));
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Finish") {
			Text msg = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
			msg.text = "";
			other.gameObject.animation.Play("LevelLoad");
		//	while(other.gameObject.animation.isPlaying);
			NextLevel();
		}
	}

	void NextLevel() {
		// call light switch level here.
		Debug.Log ("load light switch level");
	}
}
