using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour {

	private PlayerInteraction playerInteraction;

	void Update()
	{
		if (playerInteraction != null) {
			if (playerInteraction.interactable) {
				if (Input.GetButton ("Interact")) {
					Moveing (playerInteraction.interactionSpeed);
					playerInteraction.moveObject ();
					playerInteraction.interacting = true;
				} else {
					playerInteraction.interacting = false;
				}
			}
		}
	}

	public void Moveing(float speed)
	{
		transform.Translate (new Vector2(Input.GetAxis("Horizontal"), 0) * speed * Time.deltaTime);
	}
		
	void OnCollisionEnter2D(Collision2D coll)
	{
		
		if(coll.gameObject.tag == "Player")
		{
			if(playerInteraction == null)
			{
				playerInteraction = coll.gameObject.GetComponent<PlayerInteraction> ();
			}
			//interacting = 
			playerInteraction.interactable = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			//interacting = false;

			playerInteraction.interactable = false;
			playerInteraction.interacting = false;
		}
	}

}
