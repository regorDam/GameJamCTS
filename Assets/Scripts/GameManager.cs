using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private static GameManager instance;

	public static GameManager Instance 
	{

		get {return instance; }
	}
		
	void Awake()
	{
		//Check if instanbce already exist
		if (instance == null)
			//if notm set instance to this;
			instance = this;
		//If instance already exist and it's not this
		else if (instance != this)
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
