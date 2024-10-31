using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    public Animator animator;


    void PlayerAnimation()
    {
        animator.SetFloat("Horizontal", speedX);
        animator.SetFloat("Vertical", speedY);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        
    }
    void Movement()
    {
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2 (speedX, speedY);

    }

    //private void LookAtMouse()
    //{
    //    Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
    //    transform.up = (Vector3)(mousePos - new Vector2 (transform.position.x, transform.position.y));

    //    //transform.up or .down or .left or .right depends the sprite
    //}


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        
        PlayerAnimation();

        //LookAtMouse();
    }
}
