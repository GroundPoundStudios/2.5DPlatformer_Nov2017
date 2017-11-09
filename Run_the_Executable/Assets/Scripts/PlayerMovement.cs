using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 10f;
	public float groundDetectionLengthFromCenter = 1.1f;
	public int maxJumpCharges = 1;
	public int jumpCharges;
	public float jumpRechargeTimer = 0.5f;
	private bool canJump = true;
	private Rigidbody2D rgdPlayer;
	// for later
	private Animator animPlayer;

	// Use this for initialization
	void Start () 
	{
		rgdPlayer = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Left + Right movement in one.
		if(Input.GetButton("Horizontal"))
		{
			rgdPlayer.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * speed, rgdPlayer.velocity.y);
		}

		//stops sliding after left or right move button released.
		if (Input.GetButtonUp ("Horizontal")) 
		{
			rgdPlayer.velocity = new Vector2 (0, rgdPlayer.velocity.y);
		}

		//everything to do with jumping below.
		if(Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0 && jumpCharges > 0 || Input.GetButtonDown("Jump") && jumpCharges > 0)
		{
			//rgdPlayer.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
			rgdPlayer.velocity += Vector2.up * jumpForce;
			jumpCharges--;
			canJump = false;
			StartCoroutine ("Wait");
		}

		Ray2D ray = new Ray2D();
		ray.origin = new Vector2(transform.position.x, transform.position.y);
		ray.direction = Vector2.down;

		RaycastHit2D[] hit = Physics2D.RaycastAll(ray.origin, ray.direction, groundDetectionLengthFromCenter);
			
		//Debug.DrawRay (ray.origin, ray.direction * jumpRange, Color.red);
		foreach (var col in hit) {
			if (col.collider != null) {
				if (col.collider.tag == "Ground" && canJump) {
					//Debug.Log (hit.collider.tag);
					jumpCharges = maxJumpCharges;
				}
			}
		}
	}

	//Acts as a timer for the jump, otherwise jump charges immediately reset as ray cast is still touching ground after jump button is pressed.
	IEnumerator Wait()
	{
		yield return new WaitForSeconds (jumpRechargeTimer);
		canJump = true;
	}
}
