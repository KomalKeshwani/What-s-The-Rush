using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 6f, jumpForce = 10f;

    private Rigidbody2D myBody;

   // private PlayerAnimations playerAnim;
    private Animator anim;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform groundCheckPos;

    private BoxCollider2D boxCol2D;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        boxCol2D = GetComponent<BoxCollider2D>();

        //playerAnim = GetComponent<PlayerAnimations>();

    }

    private void FixedUpdate()
    {
        HandleMovementWithRigidBody();
    }

    private void Update()
    {
        HandlePlayerAnimation();
        HandleJumping();
    }

    void HandleMovementWithRigidBody()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(-runSpeed, myBody.velocity.y);
            
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2(runSpeed, myBody.velocity.y);
            
        }
        else
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
    }

    void HandlePlayerAnimation()
    {
         //playerAnim.Play_RunAnimation((int)Mathf.Abs(myBody.velocity.x));
        
        anim.SetInteger(TagManager.RUN_ANIMATION_PARAMETER, (int)Mathf.Abs(myBody.velocity.x));
       
        SetFacingDirection((int)myBody.velocity.x);

        anim.SetBool(TagManager.JUMP_ANIMATION_PARAMETER, !IsGrounded());




    }


    public void SetFacingDirection(int facingDir)
    {
        if (facingDir > 0)
            spriteRenderer.flipX = false;
        else if (facingDir < 0)
            spriteRenderer.flipX = true;
    }

    bool IsGrounded() 
    {
        // return Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.1f, groundLayer);
        return Physics2D.BoxCast(boxCol2D.bounds.center, boxCol2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    void HandleJumping()
    {

        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if(IsGrounded())
            {
                SoundController.instance.Play_PlayerJumpSound();
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.ENEMY_TAG))
            GameplayController.instance.GameOver(false);

        if (collision.CompareTag(TagManager.GOAL_TAG))
            GameplayController.instance.GameOver(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.ENEMY_TAG))
            GameplayController.instance.GameOver(false);
    }

}//class
















