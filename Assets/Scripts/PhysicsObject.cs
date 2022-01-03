using System.Collections.Generic;
using UnityEngine;

/* I created this script using a tutorial found here:
 * https://learn.unity.com/tutorial/live-session-2d-platformer-character-controller
 * I don't really understand it and I suspect it might be causing me some problems. 
 * So I'm going to try something else.
 * */
public class PhysicsObject : MonoBehaviour
{
    public const float gravityModifier = 4f;
    public const float minGroundNormalY = 0.65f;

    public bool isGrounded;
    protected Vector2 groundNormal;

    protected Vector2 targetVelocity;
    protected Vector2 velocity;
    protected Rigidbody2D body;

    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;


    void OnEnable()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    protected virtual void ComputeVelocity()
    {
    }

    protected virtual void SetAnimations()
    {
    }

    protected virtual void Update()
    {
        //targetVelocity = Vector2.zero;
        ComputeVelocity();
        SetAnimations();
    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Time.deltaTime * Physics2D.gravity;
        velocity.x = targetVelocity.x;

        isGrounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        ExecuteMovement(move, false); // Execute X axis Movement

        move = Vector2.up * deltaPosition.y;

        ExecuteMovement(move, true); // Execute Y axis Movement

    }

    void ExecuteMovement(Vector2 move, bool Ymovement)
    {
        float distance = move.magnitude;
        if (distance > minMoveDistance)
        {
            int count = body.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            foreach (RaycastHit2D hit in hitBufferList)
            {
                Vector2 hitNormal = hit.normal;

                if (hitNormal.y > minGroundNormalY)
                {
                    isGrounded = true;
                    if (Ymovement)
                    {
                        groundNormal = hitNormal;
                        hitNormal.x = 0;
                    }

                }

                float projection = Vector2.Dot(velocity, hitNormal);
                if (projection < 0)
                {
                    velocity -= (projection * hitNormal);
                }

                float modifiedDistance = hit.distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }


        body.position += move.normalized * distance;
    }

}
