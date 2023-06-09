using UnityEngine;
using UnityEngine.UI;

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
    private Animator anim;
    private SpriteRenderer sprite;
    public Slider healthBar;
    [SerializeField] private int maxHP;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        sprite = GetComponentInParent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (isTouchingPlayer)
        {
            PlayerController.instance.TakeDamage(attack);
        }
    }

    private void Update()
    {
        // Basic Movement AI. Just goes towards the player. Doesn't check for obstacles in the way
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerController.instance.transform.position, speed * Time.deltaTime);

        if (this.transform.position != PlayerController.instance.transform.position)
            // Might have to adjust this
        {
            anim.SetInteger("enemyRun", 1);
        } else
        {
            anim.SetInteger("enemyRun", 0);
        }

        if (this.transform.position.x <= PlayerController.instance.transform.position.x)
        {
            // Flip sprite
            sprite.flipX = false;
        } else
        {
            sprite.flipX = true;
        }


        if(hp <= 0)
        {
            anim.SetBool("enemyDeath", true);
            // Invoke("Die", .5f);
            Die();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "verticalComp")
        {
            // Don't allow enemies to heal if defense too high
            // Enemies must take minimum damage
            hp -= (defense - PlayerController.instance.Attack > -2) ? 2 : (PlayerController.instance.Attack - defense);

            healthBar.value = ((float)hp) / ((float)maxHP);
            anim.SetTrigger("enemyTakeDamage");
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
