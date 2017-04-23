using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

	public List<GameObject> Rats;
	public GameObject ratAudio;
	float x,z;
	float i;
	float time;

	// Use this for initialization
	void Start () {

		ratAudio = Resources.Load<GameObject> ("RatSound");
		time = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		time = time + Time.deltaTime;

		if (time > 5f) {
			
			MakeSound ();
			time = 0f;
		}

		
	}

	void MakeSound(){

		x = Random.Range (-50, 50);
		z = Random.Range (-50, 50);
		i = Random.Range (1f, 2f);

		Vector3 position = new Vector3 (x, 2, z);

		GameObject newAudio = Instantiate (ratAudio, position, Quaternion.identity) as GameObject;

		newAudio.GetComponent<AudioSource> ().pitch = i;
		newAudio.GetComponent<AudioSource> ().volume = Time.time/20;
		Debug.Log ("time:"+ (int)time + "   volume:" + newAudio.GetComponent<AudioSource> ().volume);
		
	}
}
