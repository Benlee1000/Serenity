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
            anim.SetTrigger("playerRun");
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
}