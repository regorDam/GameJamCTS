using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public Transform target;
	public Vector3 offset;

	void Update ()
	{

		transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z+offset.z);

	}
}
