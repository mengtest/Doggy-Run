using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlDog : MonoBehaviour {

	//get the rigidbody of the dog
	private Rigidbody2D dogRigidbody;
	//force in which we make the dog jump upwards
	public float dogJump = 550;
	//the current animation of the dog
	private Animator dogAnima;

	//check if the bunny is hurt or not
	private float deadTime = -1;

	//the time inside the textbox
	public Text timeBox;
	//the start time
	private float startTime;
	//the old time
	private int oldTime;

	//the score inside the textbox
	public Text scoreBox;
	//the current score
	private int score;

	//the number of lives in the textbox
	public Text lifeBox;
	//the current number of lives
	private int lives;


	// Use this for initialization
	void Start () {
		//get the ridgidbody of the dog
		dogRigidbody = GetComponent<Rigidbody2D> ();
		//get the animation for the dog
		dogAnima = GetComponent<Animator> ();

		//get the current start
		startTime = Time.time;
		//get the old time
		oldTime = 0;

		//initalize with a total score of 0
		score = 0;

		//initialize with a total of 3 lives
		lives = 3;
	}

	// Update is called once per frame
	void Update () {
		//if you are not dead and you have no more lives
		if (deadTime == -1 && lives != 0) {
			
			//if jump button has been released
			if (Input.GetButtonUp ("Jump") || Input.GetButton ("Fire1")) {
				//add force to dog and cause it to jump
				dogRigidbody.AddForce (transform.up * dogJump);
			}

			//set the animation based on the y axis velocity of the dog
			//running, jumping and falling down
			dogAnima.SetFloat ("verticalVelocity", dogRigidbody.velocity.y);

			//update the current timing
			int currentTime = (int)(Time.time - startTime);
			timeBox.text = currentTime.ToString ("0");

			//if the timing is a multiple of 5 we increase score by 1
			//double check if the old time and the current time differ by 5 seconds
			if (currentTime % 5 == 0 && currentTime != 0 && currentTime - oldTime > 1) {
				score++;
				scoreBox.text = score.ToString ("0");
				oldTime = currentTime;
			}


		} else { //if the dog has died or has no more lives left
			//1 seconds after the bunny hurt time
			if (Time.time > deadTime + 2) {
				//reset level
				SceneManager.LoadScene ("Main Scene");
			}
		}
	}

	//called when something collides with our dog
	void OnCollisionEnter2D(Collision2D collision) {
		//if the dog collides with a crate
		//the dog will die
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Crate")) {
			//the dog is considered dead
			DeadDog ();

		}

		//if the dog collides with a mushroom
		//we increase the score by 1
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Coins")) {
			//increment the score
			score++;
			scoreBox.text = score.ToString ("0");
			//destroy the mushroom
			Destroy(collision.collider.gameObject);
		}

		//if the dog collides with a bush
		//the dog will loss a life (if a dog losses 3 lives the dog dies)
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Bush")) {
			lives--;
			if (lives >= 0) {
				lifeBox.text = lives.ToString ("0");
			}
			Destroy(collision.collider.gameObject);

			if (lives <= 0) {
				//the dog is considered dead
				DeadDog ();
			}
		}

		//if the dog collides with a mushroom
		//the dog will gain a life (the dog can have a max of 3 lives at 1 time)
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Mushrooms")) {
			
			if (lives <= 0) { //if the dog has no lives
				DeadDog ();
			} else if (lives > 0 && lives < 3) { //if the dog has a live between 0 and 3
				lives++;
			} else if (lives >= 3) { //if the dog already has a max of 3 lives
				lives = 3;
			}
			//destroy the coin and update the number of lives
			Destroy(collision.collider.gameObject);
			lifeBox.text = lives.ToString ("0");

		}
	}

	void DeadDog() {
		//stop creating bushes
		foreach (MoreElements moreElements in FindObjectsOfType<MoreElements>()) {
			moreElements.enabled = false;
		}

		/*foreach (MorePlatforms morePlatforms in FindObjectsOfType<MorePlatforms>()) {
			morePlatforms.enabled = false;
		}*/

		//stop moving the elements left
		foreach (MoveLeft left in FindObjectsOfType<MoveLeft>()) {
			left.enabled = false;
		}

		//set the dog animation to "dead"
		dogAnima.SetBool ("dead", true);
		//prevent the dog from moving when the dog is dead
		dogRigidbody.velocity = Vector3.zero;
		//set the deadTime to the current time
		deadTime = Time.time;
	}
}
