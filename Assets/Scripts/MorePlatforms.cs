using UnityEngine;
using System.Collections;

public class MorePlatforms : MonoBehaviour {

	private float nextCreate = 0;
	//what to creat at this specific point

	public Transform element1;
	public Transform element2;
	public Transform element3;

	private Transform whatToCreate;

	public float lowerSpawnRate = 0.5f;
	public float upperSpawnRate = 1.0f;
	public float lowerRandomDelay = 0.5f;
	public float upperRandomDelay = 1.5f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float spawnRate = (float) Random.Range(lowerSpawnRate, upperSpawnRate);
		float randomDelay = (float) Random.Range(lowerRandomDelay, upperRandomDelay);
		float determineTransform = (float) Random.Range(0, 2);

		if (Time.time > nextCreate) {

			if (determineTransform == 0) {
				whatToCreate = element1;
			} else if (determineTransform == 1) {
				whatToCreate = element2;
			} else {
				whatToCreate = element3;
			}

			//create the new platform
			Instantiate (whatToCreate, transform.position, Quaternion.identity);

			//supply a new creation time
			nextCreate = Time.time + spawnRate + Random.Range(0, randomDelay);
		}
	}
}