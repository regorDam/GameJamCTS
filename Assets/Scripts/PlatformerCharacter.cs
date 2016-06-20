using UnityEngine;
using System.Collections;

public class PlatformerCharacter : MonoBehaviour 
{
	[SerializeField] private float m_MaxSpeed = 10f;
	[SerializeField] private float m_JumpForce = 400f;
	[Range(0,1)] [SerializeField] private float m_CrouchSpeed = .36f;
	[SerializeField] private bool m_AirControl = false;
	[SerializeField] private LayerMask m_WhatIsGround;

	private Transform m_GroundCheck;
	const float k_GroundedRadius = .2f;
	private bool m_Grounded;
	private Transform m_CeilingCheck;
	const float k_CeilingRadius = .01f;
	[HideInInspector]
	public Animator m_Anim;
	private Rigidbody m_Rigidbody;
	private bool m_FacingRight = true;


	void Awake()
	{
		//Setting up references
		m_GroundCheck = transform.Find("GroundCheck");
		m_CeilingCheck = transform.Find("CeilingCheck");
		m_Anim = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody> ();
		m_Anim.SetBool("Die", false);

	}

	void FixedUpdate()
	{
		m_Grounded = false;

		Collider[] colliders = Physics.OverlapSphere (m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);

		for (int i = 0; i < colliders.Length; i++) 
		{
			if (colliders [i].gameObject != gameObject)
				m_Grounded = true;
		}

		m_Anim.SetBool ("Ground", m_Grounded);

		m_Anim.SetFloat ("vSpeed", m_Rigidbody.velocity.y);
	}

	public void Move(float move, bool crouch, bool jump)
	{
		if (!crouch && m_Anim.GetBool ("Croush")) 
		{
			if (Physics2D.OverlapCircle (m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround)) 
			{
				crouch = true;
			}
		}

		m_Anim.SetBool ("Crouch", crouch);

		if (m_Grounded || m_AirControl) 
		{

			move = (crouch ? move * m_CrouchSpeed : move);

			m_Anim.SetFloat ("Speed", Mathf.Abs (move));

			m_Rigidbody.velocity = new Vector3 (move * m_MaxSpeed, m_Rigidbody.velocity.y, 0);

			if (move > 0 && !m_FacingRight) 
			{
				Flip ();
			} else if (move < 0 && m_FacingRight) 
			{
				Flip ();
			}
		}
		if (m_Grounded && jump && m_Anim.GetBool ("Ground")) 
		{
			Debug.Log ("jump");
			m_Grounded = false;
			m_Anim.SetBool ("Ground", false);
			m_Rigidbody.AddForce (new Vector3 (0f, m_JumpForce, 0));
		}
	}

	void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
