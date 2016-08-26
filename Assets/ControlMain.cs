using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlMain : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void StartPlaying()
	{
		SceneManager.LoadScene ("Game Scene");        
	}

	public void StartInstructions()
	{
		SceneManager.LoadScene ("Instructions Scene");        
	}

	public void StartMain()
	{
		SceneManager.LoadScene ("Main Scene");        
	}
}