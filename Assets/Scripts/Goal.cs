using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Camera.main.fieldOfView = 100;
		}
	}
}
