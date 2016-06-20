using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Restarter : MonoBehaviour 
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
