using UnityEngine;
using System.Collections;

public class MoreElements : MonoBehaviour {

	//what to creat at this specific point
	public Transform element1; //coins
	public Transform element2; //bush
	public Transform element3; //crate
	public Transform element4; //mushrooms
	private Transform whatToCreate;

	private float nextSpawn = 0;


	//as the amount of time goes on the spawn rate is randomly choosen based on the Animation Curve
	public AnimationCurve curve0;
	public AnimationCurve curve1;
	public AnimationCurve curve2;
	public AnimationCurve curve3;

	private AnimationCurve whatCurve;

	//the curve length in seconds
	public float curveLength;
	//the current start time
	private float startTime;
	public float jitter = 0.25f;

	private int determineTransformation;
	private int determineCurve;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		determineTransformation = (int) Random.Range(0, 2);
		curveLength = Random.Range(15f, 60f);
		whatCurve = chooseCurve();
	}


	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawn) {

			//figure out what to create at a specific point and create it
			whatToCreate = chooseTransform ();
			Instantiate(whatToCreate, transform.position, Quaternion.identity);

			//find the position along the current animation curve
			float position = ((Time.time - startTime) / curveLength) + Random.Range(-0.25f, 0.25f);

			// if we go past curve length we will reset start time
			// and wrap it to the beginning of the curve
			if (position > 1f)
			{
				position = 1f;
				startTime = Time.time;
				//determine a new curve and a new curve length
				whatCurve = chooseCurve ();
				curveLength = Random.Range(15f, 60f);
			}

			//calculate the next spawn time
			nextSpawn = Time.time + whatCurve.Evaluate(position) + Random.Range(-jitter, jitter);

		}
	}

	AnimationCurve chooseCurve () {
		determineCurve = (int) Random.Range(0, 4);
		if (determineCurve == 0) {
			return curve0;
		} else if (determineCurve == 1) {
			return curve1;
		} else if (determineCurve == 2) {
			return curve2;
		} else {
			return curve3;
		}
	}

	Transform chooseTransform () {
		//30% = coins, 40% = bushes, 20% = crates, 10% = mushrooms
		determineTransformation = (int) Random.Range(0, 100);
		if (determineTransformation <= 30) {
			return element1; //coins
		} else if (determineTransformation >= 31 && determineTransformation <= 70) {
			return element2; //bushes
		} else if (determineTransformation >= 71 && determineTransformation <= 90) {
			return element3; //crates
		} else {
			return element4; //mushrooms
		}
	}
}