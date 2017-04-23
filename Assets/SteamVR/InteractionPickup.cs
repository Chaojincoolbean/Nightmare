using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem; //we need this to use SteamVR code

//put this cript on your cube/thing you wnat to pick up
public class InteractionPickup : MonoBehaviour {

	//this happens whenever a hand is near this object
	void HandHoverUpdate(Hand hand){
		//this applies to either Vive controller
		if (hand.GetStandardInteractionButton () ==true) {  //on Vive controller, this is trigger
			hand.AttachObject(gameObject);
		}
		
	}
	//this happens when this object is attached to a hand, for whatever reason
	void OnAttachedToHand (Hand hand){
		GetComponent<Rigidbody> ().isKinematic = true; //turn off physics so we can hold it
	}

	//this is like "update" as long as we're holding something
	void HandAttachedUpdate (Hand hand){
		if (hand.GetStandardInteractionButton () == false) {  //on Vive controller, this is trigger
			hand.DetachObject(gameObject);
		}
	}

	void OnDetachedFromHand(Hand hand){
		GetComponent<Rigidbody> ().isKinematic = false; //turn on physics

		//apply forces to it, as if we're throwing it
		GetComponent<Rigidbody>().AddForce(hand.GetTrackedObjectVelocity(),ForceMode.Impulse);
		GetComponent<Rigidbody> ().AddTorque (hand.GetTrackedObjectAngularVelocity () * 10f, ForceMode.Impulse);


	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
