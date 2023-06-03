using UnityEngine;

/*  
 *  Abstract base class for all enemy controllers
 *  Implements an attack method, add more methods as similarities grow
 */
public abstract class EnemyController : MonoBehaviour
{
    public abstract void Attack();
}
