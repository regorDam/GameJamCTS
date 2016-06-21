using UnityEngine;
using System.Collections;

public class TrapKiller : MonoBehaviour {

	[SerializeField]
	private GameObject player;
    [SerializeField]
    private float timeSustract = 15;

	void Awake(){
		player = GameObject.FindWithTag ("Player");
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
            GameManager.Instance.TimeHit(timeSustract);
		}
	}

}
