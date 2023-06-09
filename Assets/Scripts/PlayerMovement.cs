using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float playerSpeed;
    [SerializeField] float diagonalMultiplier;
    [SerializeField] float speed;
    [SerializeField] private Animator anim;
    //vert=1.0 for up and -1.0 for down
    //horiz=1.0 for right and -1.0 for left
    void move(float vert,float horiz,float speedMultiplier){
        if(vert!=0 && horiz!=0){
            vert*=diagonalMultiplier;
            horiz*=diagonalMultiplier;
        }
        this.transform.position+=new Vector3(horiz*playerSpeed,vert*playerSpeed,0);
    }
}
//