using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.tag);
		if (other.tag == "Player")
		{
			Camera.main.fieldOfView = 80;
		}
	}
}
