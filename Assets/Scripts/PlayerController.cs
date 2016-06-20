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

	private Transform weapon;

	void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter> ();
		weapon = transform.Find ("Weapon");
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

		if (Input.GetMouseButtonDown (0)) {
			GameObject bullet = Instantiate (Resources.Load ("Prefabs/Bullet"), weapon.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.right * bullet.GetComponent<Bullet> ().Speed;
			m_Character.m_Anim.SetBool ("Shoot", true);
		} else 
		{
			DelayShoot ();
		}
	
	}


	private void DelayShoot()
	{
		time -= Time.deltaTime;
		if (time <= 0) 
		{
			time = 2;
			m_Character.m_Anim.SetBool ("Shoot", false);
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
}
