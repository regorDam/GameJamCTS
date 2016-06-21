using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{


    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }

    /*

	public Transform target;
	public Vector3 offset;

	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;

	private float m_OffsetZ;
	private Vector3 m_LastTargetPosition;
	private Vector3 m_CurrentVelocity;
	private Vector3 m_LookAheadPos;


	void Start()
	{
		//m_LastTargetPosition = target.position;
		m_OffsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	void LateUpdate ()
	{
        
		//transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z+offset.z);
        m_CurrentVelocity = Vector3.zero;
		float xMoveDelta = (target.position - m_LastTargetPosition).x;

		bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
		} else {
			m_LookAheadPos = Vector3.MoveTowards (m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
		}

        Vector3 aheadTargetPos = target.position.normalized + m_LookAheadPos + Vector3.forward * m_OffsetZ + offset;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

		transform.position = newPos;
         
        /*
        float dampTime = 0.2f; //offset from the viewport center to fix damping
        Vector3 velocity = Vector3.zero;
          if(target) 
          {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
         
         // Set this to the Y position you want the camera locked to
              destination.y = 0;
              transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
          }
        
		m_LastTargetPosition = target.position;
	}

*/
}
