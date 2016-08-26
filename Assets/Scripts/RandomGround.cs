using UnityEngine;
using System.Collections;

public class RandomGround : MonoBehaviour {

		private float nextCreate = 0;
		//what to creat at this specific point

		public Transform whatToCreate;

		//for every value of x return a value of y
		//as the game progressess the spawn rate slow down
		public AnimationCurve spawnCurve;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			float spawnRate = 0;
			float randomDelay = 0;
			if (Time.time > nextCreate) {

				//create the new bush
				Instantiate (whatToCreate, transform.position, Quaternion.identity);

				spawnRate = (float) Random.Range(0.1f, 2f);
				randomDelay = (float) Random.Range(0.1f, 2f);

				//supply a new creation time
				nextCreate = Time.time + spawnRate + Random.Range (0, randomDelay);
			}
		}
	}
