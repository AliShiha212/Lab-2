
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask ground;

    private Animator anim;
    private bool Ground;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is on the ground
       

        // Jump
        if (Input.GetKeyDown(Spacebar))
        {
            if (Ground)
            {
                GetComponent<Rigidbody2D>().velocity =
                    new Vector2(
                        GetComponent<Rigidbody2D>().velocity.x,
                        jumpHeight
                    );
            }
        }

        // Move left
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(
                    -moveSpeed,
                    GetComponent<Rigidbody2D>().velocity.y
                );

            GetComponent<SpriteRenderer>().flipX = true;
        }

        // Move right
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(
                    moveSpeed,
                    GetComponent<Rigidbody2D>().velocity.y
                );

            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Run and Idle animations
        anim.SetFloat(
            "speed",
            Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)
        );

        // Jump and Fall animations
        anim.SetFloat(
            "Height",
            GetComponent<Rigidbody2D>().velocity.y
        );

        // Check if the player is grounded for animations
        anim.SetBool("Ground", Ground);
    }

    void FixedUpdate(){

 Ground = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            ground
        );

    }
}
