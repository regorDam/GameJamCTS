﻿using UnityEngine;
using System.Collections;

public class TrapKiller : MonoBehaviour 
{

    [SerializeField]
    private float timeSustract = 15;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
            GameManager.Instance.TimeHit(timeSustract);
		}
	}

}
