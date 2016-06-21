using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlatformerCharacter))]
public class AIController : MonoBehaviour 
{
	private GameManager gameManager;
	[HideInInspector]
	public PlatformerCharacter m_Character;
	private bool m_Jump;
	public bool isDead { get; set; }
	private bool right = true;
	private float dir;

	private Transform m_CeilingCheck;   // A position marking where to check for ceilings
	const float k_CeilingRadius = .01f;

	public bool crouch;

	private Vector3 oldPosition;

	void Awake()
	{
		m_CeilingCheck = transform.Find("CeilingCheck");
		m_Character = GetComponent<PlatformerCharacter> ();
	}

	void Start () 
	{
		gameManager = GameManager.Instance;
	}


	void Update () 
	{
		/*
		if (transform.position.x == oldPosition.x)
			right = !right;
		else
			oldPosition = transform.position;
*/
		if (!right)
			dir = -1f;
		else
			dir = 1f;

		if (isDead) 
		{
			dir = 0f;
			Dead ();
		}

	}


	private void FixedUpdate()
	{
		// Read the inputs.
		crouch = false;
		float h = dir;
		// Pass all parameters to the character control script.
		m_Character.Move(h, crouch, m_Jump);
		m_Jump = false;
	}

	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Player")
		{
			if (m_CeilingCheck.position.y <= collision.gameObject.transform.position.y && !isDead)
			{
				//Debug.Log ("enemy Dead");
				Dead();
				//animation.wrapMode = WrapMode.Once;
			}
			else
			{
				//HIT

				/*
				collision.gameObject.GetComponent<PlayerController>().isDead = true;
				collision.gameObject.GetComponent<PlayerController>().m_Character.m_Anim.Play("CharacterDie");
				//collision.gameObject.transform.FindChild("Model").GetComponent<SpriteRenderer>().color = Color.red;
				collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
				collision.gameObject.GetComponent<CapsuleCollider>().enabled = false;
				*/
				gameManager.TimeHit (5f);
			}

		}
        if (collision.gameObject.layer == 8) return;
        if (collision.gameObject.layer == 9) return;
		right = !right;
	}

	void Dead()
	{
		isDead = true;
		m_Character.m_Anim.Play("CharacterDie");
		//transform.FindChild("Model").GetComponent<SpriteRenderer>().color = Color.red;
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<CapsuleCollider>().enabled = false;
	}
}
