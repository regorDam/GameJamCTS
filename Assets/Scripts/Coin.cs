using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour 
{

	public float speedRotation;
	void Update ()
	{
		transform.Rotate(Vector3.forward * speedRotation * Time.deltaTime, Space.World);


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			GameManager.Instance.AddCoin();
			Destroy(gameObject);
		}
	}
}
