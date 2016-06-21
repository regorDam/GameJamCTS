using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour 
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Camera.main.fieldOfView = 100;
			int buildIndex = SceneManager.GetActiveScene ().buildIndex;
			if (buildIndex >= 2)
				Debug.Log ("Win");
			else
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
