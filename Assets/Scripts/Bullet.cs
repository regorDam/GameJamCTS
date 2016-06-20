using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float Speed = 5f;
	// Use this for initialization


	void Start()
	{
		Destroy(gameObject, 4f);

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag.Equals ("Player")) 
		{
			//Player hit
		} else if (other.transform.tag.Equals ("Enemy")) 
		{
			Destroy (other.gameObject);
			//init powerUP
			Destroy (gameObject);
			//Instantiate(Resources.Load("Prefabs/ "), other.transform.position, Quaternion.identity);
		}
			

			
	}
}
