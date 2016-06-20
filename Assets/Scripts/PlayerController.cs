using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(PlatformerCharacter))]
public class PlayerController : MonoBehaviour 
{
	private GameManager gameManager;
	[HideInInspector]
	public PlatformerCharacter m_Character;
	private bool m_Jump;
	public bool isDead { get; set; }
	private float time = 2;

	void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter> ();
	}

	void Start () 
	{
		gameManager = GameManager.Instance;
	}
	

	void Update () 
	{
		if (!m_Jump)
		{
			//m_Jump = Input.GetButtonDown("Jump");
			m_Jump = Input.GetKeyDown(KeyCode.Space);
		}

		if(isDead)
		{
			time -= Time.deltaTime;
			if(time < 0)
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	
	}


	private void FixedUpdate()
	{
		if (isDead) return;
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = Input.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		m_Character.Move(h, crouch, m_Jump);
		m_Jump = false;
	}

	void ReadInputs()
	{


	}
}
