using UnityEngine;
using System.Collections;

public class Recycle : MonoBehaviour {

	public Transform start;
	public Transform end;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (transform.position.x < end.position.x)
		{
			transform.position = new Vector3(start.position.x - (end.position.x - transform.position.x), transform.position.y, transform.position.z);
		}

	}
}