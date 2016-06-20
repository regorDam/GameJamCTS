using UnityEngine;
using System.Collections;


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

	[HideInInspector][Range(0,1)]
	public int weaponRole;
	public bool canFire { get; set; }

	void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter> ();
		weapon = transform.Find ("Weapon");
	}

	void Start () 
	{
		weaponRole = 0;
		isDead = false;
		canFire = false;
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
			Debug.Log ("Player is dead");
			time -= Time.deltaTime;
			if (time < 0) 
			{
				isDead = true;
				m_Character.m_Anim.Play("CharacterDie");
				GameManager.Instance.Restart ();
			}
		}

		if (Input.GetMouseButtonDown (0) && canFire) {
			GameObject bullet = Instantiate (Resources.Load ("Prefabs/Bullet"+weaponRole), weapon.position, Quaternion.identity) as GameObject;
			float speed = bullet.GetComponent<Bullet> ().Speed;
			if (!m_Character.m_FacingRight)
				speed *= -1;
			bullet.GetComponent<Rigidbody> ().velocity = (weapon.right) * speed;
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
