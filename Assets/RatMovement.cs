using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour {

	public GameObject player;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		Vector3 direction = (this.transform.position - player.transform.position);
//		direction.Normalize ();
//		this.transform.position = direction * speed * Time.deltaTime;

		this.transform.position = Vector3.MoveTowards (this.transform.position, player.transform.position+ new Vector3(0,10.4f,0), speed * Time.deltaTime);
	}

	void OncollisionEnter(Collision collision){

		if (collision.gameObject.name == "Wall") {
			
			foreach (ContactPoint contact in collision.contacts) {
				Debug.Log ("wall");
			
			}
		}
	}
}
