using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MovePlayer : MonoBehaviour
{
    //maximum speed
    float maxSpeed=10;
    //how quickly the player can get near it's top speed
    float defaultSharpness=8;
    float decelSpeed;
    float glideDecelSpeed=60;
    Vector2 playerVel= new Vector2(0,0);
    //For testing purposes, set to a small number <1, otherwise set to 1
    float testMult=1.0f;
    // Start is called before the first frame update

    // Velocity models equation maxSpeed(1-e^(-defautSharpness*t))
    // Acceleration is maxSpeed*defaultSharpness*e^(-defaultSsharpness*t)
    [SerializeField] private Animator anim;
    void Start()
    {
        decelSpeed=maxSpeed*defaultSharpness;
        //maxSpeed*=testMult;
        defaultSharpness*=testMult;
        decelSpeed*=testMult;
        glideDecelSpeed*=testMult;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Takes in a vector of (-1,-1), (-1,0), (-1,1), (0,-1), (0,0), (0,1), (1,-1), (1,0), (1,1)
    public void MovePlayerFunction(Vector2 movement){
        //Vector2 realSharpness=movement*defaultSharpness;
        Vector2 playerPos=this.transform.position;
        float a=0;
        // x axis
        
        if(movement.x*playerVel.x>0 || playerVel.x==0){
            a=(Math.Abs(playerVel.x)-maxSpeed)*(0-defaultSharpness)*Math.Sign(movement.x);
            
        }
        else if(movement.x*playerVel.x<0){
            a=0-decelSpeed*Math.Sign(playerVel.x);
        }
        else{
            a=-glideDecelSpeed*(playerVel.x/maxSpeed);
        }
        playerVel.x+=a*Time.deltaTime;
        //print(a);
        
        // y axis
        if(movement.y*playerVel.y>0 || playerVel.y==0){
            a=(Math.Abs(playerVel.y)-maxSpeed)*(0-defaultSharpness)*Math.Sign(movement.y);
            
        }
        else if(movement.y*playerVel.y<0){
            a=0-decelSpeed*Math.Sign(playerVel.y);
        }
        else{
            a=-glideDecelSpeed*(playerVel.y/maxSpeed);
        }
        playerVel.y+=a*Time.deltaTime;

        float min = 0.1f;
        if (Mathf.Abs(playerVel.x) >= min || Mathf.Abs(playerVel.y) >= min)
        {
            anim.SetInteger("RunSpeed", 1);
        } else
        {
            anim.SetInteger("RunSpeed", 0);
        }

        this.transform.position=playerPos+playerVel*Time.deltaTime;
        
    }
    void playerAbruptSetVelocity(Vector2 newVel){
        playerVel=newVel;
    }
}
