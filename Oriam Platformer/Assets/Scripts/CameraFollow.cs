using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// (2017) At the moment here, the main problem with this script is that the camera won't follow the target down and right at the same time. It will not follow down until the character has been centered.

// (Oct 2021) Bro idk how any of this works anymore but i'm tryna tweak these static values and I can't get any combination of them to even affect the camera movement at all bro idk whats going on

public class CameraFollow : MonoBehaviour
{
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;

    public bool strictFollow = false;

    private Transform target;
    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;

    public void SetTarget(Transform t)
    {
        target = t;
    }

    // Use this for initialization
    private void Start()
    {
        m_LastTargetPosition = target.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;
        if (strictFollow)
        {
            damping = 0.0f;
        }
    }

    // Update is called once per frame
    private void Update()
    {


        float xMoveDelta = (target.position - m_LastTargetPosition).x;
        float yMoveDelta = (target.position - m_LastTargetPosition).y;

        // only update lookahead pos if accelerating or changed direction
        bool updateLookAheadTarget = (Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold || Mathf.Abs(yMoveDelta) > lookAheadMoveThreshold);
        // bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);
        transform.position = newPos;
        m_LastTargetPosition = target.position;

    }

    /*public float CameraZ;
	public GameObject target;

	public float followSpeed;
	public float followThreshold;

	public void SetTarget (GameObject t)
	{
		target = t;
	}

	private Vector3 currentOffset;
	private Vector2 screenCenter;
	private Vector3 newPosition;

	void Start ()
	{
		newPosition = new Vector3 (0, 0, CameraZ);
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		currentOffset = target.transform.position - transform.position;
		if (Mathf.Abs (currentOffset.x) >= followThreshold || Mathf.Abs (currentOffset.y) >= followThreshold) { 
			//Only move the camera if the player is far enough away from the threshold

			newPosition.x = transform.position.x;
			newPosition.y = transform.position.y;


			if (currentOffset.x > 0){
				newPosition.x += followSpeed;
			} else if (currentOffset.x < 0) {
				newPosition.x -= followSpeed;
			}

			if (currentOffset.y > 0) {
				newPosition.y += followSpeed;
			} else if (currentOffset.x < 0) {
				newPosition.y -= followSpeed;
			}
		}

		transform.SetPositionAndRotation (newPosition, Quaternion.identity);

	}
	*/
}
