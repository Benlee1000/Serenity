using UnityEngine;

/*  
 *  Abstract base class for all enemy controllers
 *  Implements an attack method, add more methods as similarities grow
 */
public class EnemyController : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int speed;
    private bool isTouchingPlayer = false;

    private void FixedUpdate()
    {
        if (isTouchingPlayer)
        {
            PlayerController.instance.TakeDamage(attack);
        }
    }

    private void Update()
    {
        //Basic Movement AI. Just goes towards the player. Doesn't check for obstacles in the way
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerController.instance.transform.position, speed * Time.deltaTime);

        if(hp <= 0)
        {
            Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Player")
        {
            isTouchingPlayer = true;
        }
         
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Player")
        {
            isTouchingPlayer = false;
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        EnemySpawner.instance.numberOfEnemies--;
    }

}
