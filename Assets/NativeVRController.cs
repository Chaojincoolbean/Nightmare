using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR; //we need this to use VR functions


public class NativeVRController : MonoBehaviour {

	[SerializeField] Transform leftHand, rightHand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		leftHand.localPosition = InputTracking.GetLocalPosition (VRNode.LeftHand);
		leftHand.localRotation = InputTracking.GetLocalRotation (VRNode.LeftHand);

		rightHand.localPosition = InputTracking.GetLocalPosition (VRNode.RightHand);
		rightHand.localRotation = InputTracking.GetLocalRotation (VRNode.RightHand);
		
	}
}
