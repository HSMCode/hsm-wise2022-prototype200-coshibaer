using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //for flipping
    float inputHorizontal;
    float inputVertical;
    bool facingRight = false;
    float speed = 10f;

    public float moveSpeed = 1.5f;
    public float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;
    
    Vector2 movementInput;
    Rigidbody2D rb;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
      // If movement input is not 0, try to move
      if(movementInput != Vector2.zero)
      {
        bool success = TryMove(movementInput);

        //slide around objects to make movement smoother
        if(!success)
        {
            success = TryMove(new Vector2(movementInput.x, 0));

             if(!success)
        
             {
            success = TryMove(new Vector2(0, movementInput.y));
            }
        }

      //following is for flipping
      inputHorizontal = Input.GetAxisRaw("Horizontal");
      inputVertical = Input.GetAxisRaw("Vertical");

      if (inputHorizontal != 0)
      {
            rb.AddForce(new Vector2 (inputHorizontal * speed, 0f));
      } 
      if (inputHorizontal > 0 && !facingRight)
      {
            Flip();
      }
      if (inputHorizontal < 0 && facingRight)
      {
            Flip();
      }    
      }

    }

    //player flips according to walk direction
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }


    private bool TryMove(Vector2 direction)
    {
        //Check for collisions
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if(count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } 
            else
            {
                return false;
            }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
