using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
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
    List<Vector3> tops;
    // Velocity models equation maxSpeed(1-e^(-defautSharpness*t))
    // Acceleration is maxSpeed*defaultSharpness*e^(-defaultSsharpness*t)
    [SerializeField] private Animator anim;
    void Start()
    {
        
        
        //print(decelSpeed);
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
    public Vector2 MovePlayerFunction(Vector2 movement,float speed){
        maxSpeed=speed;
        //setObstacles();
        //Vector2 realSharpness=movement*defaultSharpness;
        decelSpeed=maxSpeed*defaultSharpness;
        Vector2 playerPos=this.transform.position;
        float a=0;
        // x axis
        float sharpness=defaultSharpness;
        float modifiedDecelSpeed=decelSpeed;
        float modifiedMaxSpeed=maxSpeed;
        if(movement.x*movement.y!=0){
            sharpness*=0.75f;
            modifiedDecelSpeed*=0.75f;
            modifiedMaxSpeed*=0.75f;
        }
        if(movement.x*playerVel.x>0 || playerVel.x==0){
            a=(Math.Abs(playerVel.x)-modifiedMaxSpeed)*(0-sharpness)*Math.Sign(movement.x);
        }
        else if(movement.x*playerVel.x<0){
            a=0-modifiedDecelSpeed*Math.Sign(playerVel.x);
        }
        else{
            a=-glideDecelSpeed*(playerVel.x/maxSpeed);
        }
        playerVel.x+=a*Time.deltaTime;
        
        //print(a);
        
        // y axis
        if(movement.y*playerVel.y>0 || playerVel.y==0){
            a=(Math.Abs(playerVel.y)-modifiedMaxSpeed)*(0-sharpness)*Math.Sign(movement.y);
            
        }
        else if(movement.y*playerVel.y<0){
            //print("bbb");
            a=0-modifiedDecelSpeed*Math.Sign(playerVel.y);
            //print(decelSpeed);
            //print(Math.Sign(playerVel.y));
        }
        else{
            a=-glideDecelSpeed*(playerVel.y/maxSpeed);
        }
        
        playerVel.y+=a*Time.deltaTime;
        /*
        if(playerVel.y>0){
            foreach(Vector3 edge in tops){
                if(playerPos.y<edge.z && playerPos.y+playerVel.y*Time.deltaTime>edge.z){
                    if(playerPos.x>edge.x && playerPos.x<edge.y ){
                        playerVel.y=(edge.z-playerPos.y)/Time.deltaTime;
                        print("bbb");
                    }
                }
            }
        }*/
        //print(playerVel);

        return playerVel;
        //this.transform.position=playerPos+playerVel*Time.deltaTime;
        
    }
    public void playerAbruptSetVelocity(Vector2 newVel){
        playerVel=newVel;
    }
    private void setObstacles(){
        tops = new List<Vector3>();
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        if(sceneName=="Level1"){
            tops.Add(new Vector3(-18.5f,-1f,8.2f));
            tops.Add(new Vector3(1.5f,18.5f,8.2f));
            //bottoms.add(new Vector3(-18.5,18.5,-8));
        
        }
        //print(sceneName);
        //-1,1.5
    }
}
