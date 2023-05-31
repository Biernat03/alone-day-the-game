using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
   public float moveSpeed = 5f;

    public Rigidbody2D rigidBody;
    public Animator animator;
    private float horizontalInput;
    private HandPivot handPivot;
    public Camera camera;

    Vector2 movement;
    Vector2 mousePos;

    private void Awake()
    {
        handPivot = GetComponentInChildren<HandPivot>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        handPivot.pointerPosition = mousePos;

        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Horizontal",movement.x);
        animator.SetBool("runUpDown", movement.y != 0);
        animator.SetBool("runLeftRight",movement.x !=0);
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    
        Vector2 lookDir = mousePos - rigidBody.position;

        if (lookDir.x> 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }  
        else if (lookDir.x < -0.01f)
        {
             transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
}
