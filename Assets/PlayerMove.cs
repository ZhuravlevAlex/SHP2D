// GroundFeet а не Ground
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private Animator animator;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private int maxJumps = 1;

    private const int noJump = 0, jumpRise = 1, jumpFall = 2;
    private int jumps = 0;
    private GroundFeet ground = null;
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ground = GetComponentInChildren<GroundFeet>();
    }
    private bool doJump = false;
    void Update()
    {
        //doJump |= (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) 
        //    && ground.IsGrounded();
        doJump |= (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && jumps < maxJumps;
    }
    private void FixedUpdate()
    {
        Vector2 motion = rbody2D.velocity;
        if (doJump)
        {
            doJump = false;
            motion.y = jumpForce;
            animator.SetInteger("jumpState", jumpRise);
            jumps++;
        }
        if (ground.IsGrounded() == false)
        {
            animator.SetInteger("jumpState", jumpFall);
        }
        if (ground.IsGrounded() == true)
        {
            animator.SetInteger("jumpState", noJump);
            jumps = 0;
        }
        var input = Input.GetAxis("Horizontal");

        if (input == 0)
        {
            animator.SetBool("IsWalk", false);
        }
        else
        {
            animator.SetBool("IsWalk", true);
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(input);
            transform.localScale = scale;
        }
        animator.SetBool("IsWalk", input != 0);
        print(input);
        motion.x = input * maxSpeed;
        rbody2D.velocity = motion;
    }
}