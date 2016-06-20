using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {


	public int type;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			GameManager.Instance.AddRole (type);
			Destroy (gameObject);
		}
	}

}
