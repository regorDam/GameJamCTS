using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float Speed = 5f;
	// Use this for initialization


	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag.Equals ("Player")) 
		{
			//Player hit
		} else if (other.transform.tag.Equals ("Player")) 
		{
			//Enemy hit
		} else
			Destroy (gameObject);
	}
}
