using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

	//how fast moving left
	public float speed = 15;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//moving left by "speed" units per seconds
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
}