using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [System.Serializable]
    public class MovementSettings
    {
        public float acceleration = 1.2f;
        public float deceleration = .85f;
        public float walkSpeed = 1.0f;
        public float sprintSpeed = 1.5f;
        public float sneakSpeed = .5f;
        public float jumpHeight;
        public float hangTime;
        public float fallSpeed;
    }
    [System.Serializable]
    public class AttackSettings
    {
        public int damage;
        public float groundAttackDelay;
        public float airAttackDelay;
        public float sneakAttackDelay;
        public float hiddenAttackDelay;
    }
    public MovementSettings movementSettings = new MovementSettings();
    public AttackSettings attackSettings = new AttackSettings();
    PlayerStates states;
    Vector2 velocity;
    private float maxSpeed;
    public Animator animator;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        states = gameObject.GetComponent<PlayerStates>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); //figure out a good way to differentiate between keys, pad, and sticks 
        
        
        DeleteInFuture(moveHorizontal);

        DetermineAttackState();
        DetermineMovementState(moveHorizontal);
        HandleHorizontalMovement(moveHorizontal);
        HandleVerticalMovement(movementSettings);

     

        transform.Translate(velocity * Time.deltaTime);
    }
    void ApplyFallSpeedWhenMidair()
    {
        if (states.neutralStates == PlayerStates.NeutralStates.midair)
        {
            velocity.y = -movementSettings.fallSpeed * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }
    }
    void DeleteInFuture(float moveHorizontal)
    {
        Vector3 scale = transform.localScale;
        if (moveHorizontal < 0)
        {
            scale.x = -1;
            transform.localScale = scale;
        }
        else
        {
            scale.x = 1;

            transform.localScale = scale;
        }

    }
    void DetermineNeutralState(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "WallRight":
                states.neutralStates = PlayerStates.NeutralStates.walledRight;
                break;
            case "WallLeft":
                states.neutralStates = PlayerStates.NeutralStates.walledLeft;
                break;
            case "Ground":
                states.neutralStates = PlayerStates.NeutralStates.grounded;
                break;
        }
    }

    void DetermineMovementState(float moveHorizontal)
    {
        
        if (moveHorizontal != 0)
        {
            if (Input.GetButton("Sneak"))
            {
                states.movementStates = PlayerStates.MovementStates.sneakMoving;
            }
            else if(Input.GetButton("Sprint"))
            {
                states.movementStates = PlayerStates.MovementStates.sprinting;
            }
            else if(Input.GetAxis("Horizontal") !=0)
            {
                states.movementStates = PlayerStates.MovementStates.walking;
            }
            
        }

        else 
        {

            if (!Input.GetButton("Jump") && Input.GetButton("Sneak"))
            {
                states.movementStates = PlayerStates.MovementStates.sneakIdle;
            }
            else if (!Input.GetButton("Jump"))
            {
                states.movementStates = PlayerStates.MovementStates.idle;
            }
        }
        
    }

    void DetermineAttackState()
    {
        if (Input.GetAxis("Attack") != 0 && states.attackStates != PlayerStates.AttackStates.neutral)
        {
            if (states.neutralStates == PlayerStates.NeutralStates.grounded)
            {
                
            }
        }
    }

    IEnumerator groundAttack()
    {
        states.attackStates = PlayerStates.AttackStates.groundAttack;
        animator.SetBool("groundAttack", true);
        yield return null;
        animator.SetBool("groundAttack", false);
        yield return new WaitForSeconds(attackSettings.groundAttackDelay);
        states.attackStates = PlayerStates.AttackStates.neutral;
    }

    void HandleVerticalMovement(MovementSettings movementSettings)
    {
        //jumpy jumpy no fall yet
        if (Input.GetButton("Jump") && states.neutralStates != PlayerStates.NeutralStates.midair)
        {
            StartCoroutine(jump(movementSettings));
        }
        

    }

    IEnumerator jump(MovementSettings movmentSettings)
    {
        rb.AddForce(Vector2.up * movmentSettings.jumpHeight, ForceMode2D.Impulse);
        yield return new WaitForSeconds(movmentSettings.hangTime);
        rb.AddForce(Vector2.down * movmentSettings.fallSpeed, ForceMode2D.Impulse);
        
    }

    void HandleHorizontalMovement(float moveHorizontal)
    {
        if (states.movementStates != PlayerStates.MovementStates.idle || states.movementStates != PlayerStates.MovementStates.sneakIdle &&
            states.neutralStates == PlayerStates.NeutralStates.grounded)
        {
            
            if (states.movementStates == PlayerStates.MovementStates.sneakMoving)
            {
                AdjustHorizontalVelocity(moveHorizontal, movementSettings.acceleration, movementSettings.sneakSpeed);
            }
            else if (states.movementStates == PlayerStates.MovementStates.sprinting)
            {
                AdjustHorizontalVelocity(moveHorizontal, movementSettings.acceleration, movementSettings.sprintSpeed);
            }
            else
            {
                AdjustHorizontalVelocity(moveHorizontal, movementSettings.acceleration, movementSettings.walkSpeed);
                
            }
        }

        if (states.movementStates == PlayerStates.MovementStates.idle)
        {
            ApplyDeceleration(movementSettings.deceleration);
            if (Mathf.Abs(velocity.x) < .1)
            {
                velocity.x = 0;
            }
        }
        if (moveHorizontal * velocity.x < 0)
        {
            ApplyDeceleration(movementSettings.deceleration);
        }
    }

    void AdjustHorizontalVelocity(float moveHorizontal, float acceleration, float maxSpeed)
    {
        velocity.x = Mathf.MoveTowards(velocity.x, moveHorizontal * maxSpeed, acceleration * Time.deltaTime);
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        //Debug.Log(velocity); 
    }

    void ApplyDeceleration(float deceleration)
    {
        velocity.x = Mathf.Lerp(velocity.x, 0, deceleration);
    }
    void OnCollisionExit2D(Collision2D other)
    {
        states.neutralStates = PlayerStates.NeutralStates.midair;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        foreach(ContactPoint2D hitPos in other.contacts)
        {
            if (hitPos.normal.x > 0)
            {
                Debug.Log("Walled Left");
                states.neutralStates = PlayerStates.NeutralStates.walledLeft;
            }else if (hitPos.normal.x < 0)
            {
                Debug.Log("Walled Right");
                states.neutralStates = PlayerStates.NeutralStates.walledRight;
            }
            else if (hitPos.normal.y > 0)
            {
                Debug.Log("Grounded");
                states.neutralStates = PlayerStates.NeutralStates.grounded;
            }
        }
    }
    void HandleColliderIntersections()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);
        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }
        }
    }
   
}
