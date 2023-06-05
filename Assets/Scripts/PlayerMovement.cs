using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int moveSpeed;
    public int dashSpeed = 10;
    [SerializeField] private GameObject playerObject;
    private PlayerController playerController;
    private Vector2 movementDirection;
    private float timeSinceLastDash = 0f;
    private float dashCooldown = 2f;

    [SerializeField] private Animator anim;

    private void Update()
    {
        timeSinceLastDash += Time.deltaTime;

        //Getting speed based off of playercontroller because speed can change
        playerController = playerObject.GetComponent<PlayerController>();

        moveSpeed = playerController.Speed; 

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movementDirection != new Vector2(0,0))
        {
            //anim.SetTrigger("playerRun");
            anim.SetInteger("RunSpeed", 1);
            CheckPlayerOrientation(movementDirection);

        } 
        else
        {
            anim.SetInteger("RunSpeed", 0);
        }

        playerObject.transform.Translate(movementDirection * Time.deltaTime * moveSpeed);

        
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastDash >= dashCooldown)
        {
            Dash();
        }
    }

    private void Dash()
    {
        timeSinceLastDash = 0;
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerObject.transform.Translate(movementDirection * Time.deltaTime * dashSpeed);
    }

    private void CheckPlayerOrientation(Vector2 movementDirection)
    {
        if (movementDirection.x != 0)
        {
            if (MovingRight(movementDirection))
            {
                playerObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                playerObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    private bool MovingRight(Vector2 moveDirection)
    {
        if (moveDirection.x > 0)
        {
            return true;
        }
        return false;
    }


}