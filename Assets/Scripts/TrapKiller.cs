using UnityEngine;
using System.Collections;

public class TrapKiller : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	void Awake(){
		player = GameObject.FindWithTag ("Player");
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			player.GetComponent<PlayerController> ().isDead = true;
		}
	}

}
