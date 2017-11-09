using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	bool leverOn = false;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("is lever on? = " + leverOn);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
	}

	void Toggle()
	{
		leverOn = true || false;
		Debug.Log ("is lever on? = " + leverOn);
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.tag == "Player") 
		{
			if (Input.GetButton ("Interact")) 
			{
				Toggle ();
			}
		}
	}

}
