using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInteraction : MonoBehaviour {

	[HideInInspector]
	public bool interacting;
	[HideInInspector]
	public bool interactable;
	public float interactionSpeed = 5f;

	public void moveObject()
	{
		transform.Translate (new Vector2(Input.GetAxis("Horizontal"), 0) * interactionSpeed * Time.deltaTime);
	}
}
