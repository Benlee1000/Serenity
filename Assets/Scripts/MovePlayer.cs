using UnityEngine;
using System;

/* 
 * Advanced player movement script
 */
public class MovePlayer : MonoBehaviour
{
    // Maximum speed
    float maxSpeed;
    // How quickly the player can get near it's top speed
    float defaultSharpness = 8;
    float decelSpeed;
    float glideDecelSpeedMult=0.75f;
    float glideDecelSpeed;
    Vector2 playerVel = new Vector2(0,0);
    // For testing purposes, set to a small number <1, otherwise set to 1
    float testMult = 1.0f;
    float a = 0;

    // Velocity models equation maxSpeed(1-e^(-defautSharpness*t))
    // Acceleration is maxSpeed*defaultSharpness*e^(-defaultSsharpness*t)
    [SerializeField] private Animator anim;

    void Start()
    {
        defaultSharpness *= testMult;
        decelSpeed *= testMult;
        glideDecelSpeed *= testMult;
    }

    // Takes in a vector of (-1,-1), (-1,0), (-1,1), (0,-1), (0,0), (0,1), (1,-1), (1,0), (1,1)
    public Vector2 MovePlayerFunction(Vector2 movement, float speed) 
    {
        maxSpeed = speed;
        decelSpeed = maxSpeed*defaultSharpness;
        glideDecelSpeed=decelSpeed*glideDecelSpeedMult;

        // X axis
        float sharpness = defaultSharpness;
        float modifiedDecelSpeed = decelSpeed;
        float modifiedMaxSpeed = maxSpeed;
        if(movement.x * movement.y != 0){
            sharpness *= 0.75f;
            modifiedDecelSpeed *= 0.75f;
            modifiedMaxSpeed *= 0.75f;
        }
        if(movement.x * playerVel.x > 0 || playerVel.x == 0) 
        {
            a = (Math.Abs(playerVel.x) - modifiedMaxSpeed) * (0 - sharpness) * Math.Sign(movement.x);
        }
        else if(movement.x * playerVel.x < 0)
        {
            a = 0 - modifiedDecelSpeed * Math.Sign(playerVel.x);
        }
        else{
            a = -glideDecelSpeed * (playerVel.x / maxSpeed);
        }
        playerVel.x += a * Time.deltaTime;
        
        // Y axis
        if(movement.y * playerVel.y > 0 || playerVel.y == 0) 
        {
            a = (Math.Abs(playerVel.y) - modifiedMaxSpeed) * (0 - sharpness) * Math.Sign(movement.y);
            
        }
        else if(movement.y * playerVel.y < 0)
        {
            a = 0 - modifiedDecelSpeed * Math.Sign(playerVel.y);
        }
        else
        {
            a = - glideDecelSpeed * (playerVel.y / maxSpeed);
        }
        
        playerVel.y += a * Time.deltaTime;

        return playerVel; 
    }

    public void playerAbruptSetVelocity(Vector2 newVel) 
    {
        playerVel = newVel;
    }
}
