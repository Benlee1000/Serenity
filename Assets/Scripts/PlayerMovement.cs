using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float playerSpeed;
    [SerializeField] float diagonalMultiplier;
    [SerializeField] float speed;
    void move(int vert,int horiz,int speedMultiplier){
        if(vert!=0 && horiz!=0){
            vert*=diagonalMultiplier;
            horiz*=diagonalMultiplier;
        }
        this.position+=Vector3(horiz*playerSpeed,vert*playerSpeed,0);
    }
}
