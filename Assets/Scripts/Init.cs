using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour 
{
	[Tooltip("Target Frame Rate")]
	public int frameRate = 60; 


	void Awake()
	{
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = frameRate;
	}

}
