using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

	public List<GameObject> Rats;
	public GameObject rat;
	public GameObject BloodSound;
	public GameObject player;
	public GameObject plane;
	public GameObject BloodParticles;
	public float speed;
	private float x,y,t;
	private float n;
	public float time;
	public float planespeed;




	// Use this for initialization
	void Start () {

		rat = Resources.Load<GameObject> ("ratPrefab");
		x = y = t= 0f;
		n = -7f;
		time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		MakeRats ();

		Debug.Log (Time.time);

		time = time + Time.deltaTime;

		for (int i = 0; i < Rats.Count; i++) {

			//Debug.Log ("x:"+ Mathf.Abs (Rats [i].transform.position.x)+ "y:"+ Mathf.Abs (Rats [i].transform.position.z));

			float x = Rats [i].transform.position.x;
			float z = Rats [i].transform.position.z;

			if ( Mathf.Pow(x,2) + Mathf.Pow(z,2) > n) {
			
				Rats [i].transform.position = Vector3.MoveTowards (Rats [i].transform.position, player.transform.position, speed * Time.deltaTime);
				Rats [i].transform.LookAt (player.transform.position);
			}

			if (time > 3) {
				n = n + 2.5f;
				//Debug.Log (n);
				time = 0;
			}
		}

		if (Time.time > 30f) {

			BloodSound.SetActive (true);
			BloodParticles.SetActive (true);

			if (plane.transform.position.y <= 1f) {
			
				plane.transform.position = new Vector3 (0, (Time.time - 30f) * planespeed, 0);
				BloodParticles.transform.position = new Vector3 (0, (Time.time - 30f) * planespeed, 0);

				for (int i = 0; i < Rats.Count; i++) {
					Rats [i].transform.position = new Vector3 (
						Rats [i].transform.position.x,
						(Time.time - 30f) * planespeed,
						Rats [i].transform.position.z
					);
				}
			}

		}


		
	}

	void MakeRats(){

		t = Random.Range(0, 360);

		x = 50f* Mathf.Cos(t);
		y = 50f* Mathf.Sin(t);

		Vector3 position = new Vector3 (x, 0, y);

		GameObject newRat = Instantiate (rat, position, Quaternion.identity) as GameObject;

		newRat.transform.position = Vector3.MoveTowards (position, player.transform.position, speed * Time.deltaTime);

		Rats.Add (newRat);

	}
}
