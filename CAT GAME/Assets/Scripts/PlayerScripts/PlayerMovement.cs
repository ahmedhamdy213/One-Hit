using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Player;
    public Animator Anim;
    public float MoveForward;
    public SpriteRenderer Flip;
    public BoxCollider2D Coll;
    [SerializeField] public LayerMask JumpableGround;

    [SerializeField] private float JumpForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    public enum MovementState { Idle, Running, Jumping, Falling, Hit }

    // Update is called once per frame
    void Update()
    {
        MoveForward = Input.GetAxisRaw("Horizontal");
        Player.velocity = new Vector2(MoveForward * 7f, Player.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Player.velocity = new Vector2(Player.velocity.x, JumpForce);
        }

        UpdateAnimationState();

    }

    public void UpdateAnimationState()
    {
        MovementState state;



        if (MoveForward > 0f)
        {
            state = MovementState.Running;
            transform.rotation = Quaternion.Euler(0, 0, 0);


        }
        else if (MoveForward < 0f)

        {
            state = MovementState.Running;
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else

        {
            state = MovementState.Idle;
        }

        if (Player.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;
        }
        else if (Player.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }
        
        Anim.SetInteger("State", (int)state);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(Coll.bounds.center, Coll.bounds.size, 0f, Vector2.down, 0.1f, JumpableGround);
    }
}
