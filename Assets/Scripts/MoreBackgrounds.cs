using UnityEngine;
using System.Collections;

public class MoreBackgrounds : MonoBehaviour {

	//what to creat at this specific point
	public Transform element1; //mushroom
	public Transform element2; //bush
	public Transform element3; //crate
	public Transform element4; //coin
	public Transform element5;

	private float nextSpawn = 0;
	//what to creat at this specific point
	private Transform whatToCreate;

	//slow down the spawn rate
	public float slowSpawn;

	//as the amount of time goes on the spawn rate is shorter and shorter
	public AnimationCurve whatCurve;

	//the curve length in seconds
	public float curveLength;
	//the current start time
	private float startTime;

	private int determineTransformation;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		determineTransformation = (int) Random.Range(0, 2);
		curveLength = Random.Range(15f, 60f);
	}


	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawn) {

			whatToCreate = chooseTransform ();
			//figure out what to create at a specific point and create it
			Instantiate(whatToCreate, transform.position, Quaternion.identity);

			//find the position along the current animation curve
			float position = ((Time.time - startTime) / curveLength);

			// if we go past curve length we will reset start time
			// and wrap it to the beginning of the curve
			if (position > 1f)
			{
				position = 1f;
				startTime = Time.time;
			}

			//calculate the next spawn time
			nextSpawn = whatCurve.Evaluate(position) * slowSpawn;

		}
	}


	Transform chooseTransform () {
		//30% = mushrooms, 40% = bushes, 20% = crates, 10% = coins
		determineTransformation = (int) Random.Range(0, 100);
		if (determineTransformation <= 20) {
			return element1; //mushrooms
		} else if (determineTransformation >= 21 && determineTransformation <= 40) {
			return element2; //bushes
		} else if (determineTransformation >= 41 && determineTransformation <= 60) {
			return element3; //crates
		} else if (determineTransformation >= 61 && determineTransformation <= 80) {
			return element4; //crates
		} else {
			return element5; //coins
		}
	}
}