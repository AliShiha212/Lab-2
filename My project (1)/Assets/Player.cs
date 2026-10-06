
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

    void Start()
    {
    }

    void Update()
    {
        
        if (Input.GetKeyDown(Spacebar))
        {
            if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground))
            {
                GetComponent<Rigidbody2D>().velocity =
                    new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            }
        }

        
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            GetComponent<SpriteRenderer>().flipX = true;
        }

        
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
