using UnityEngine;
using System.Collections;

public class DestroyObjects : MonoBehaviour {

	//When triggered you will destroy the object that touches this object
	void OnTriggerEnter2D(Collider2D other) {

		//destroys the game object
		Destroy(other.gameObject);
	}
}
