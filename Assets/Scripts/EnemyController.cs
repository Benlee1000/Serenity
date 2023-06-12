using UnityEngine;
using UnityEngine.UIElements;

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
    private float healthBar;
    [SerializeField] private int maxHP;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        sprite = GetComponentInParent<SpriteRenderer>();
        healthBar = GetComponentInChildren<Canvas>().GetComponent<Slider>().value;
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
        //Basic Movement AI. Just goes towards the player. Doesn't check for obstacles in the way
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerController.instance.transform.position, speed * Time.deltaTime);

        if (this.transform.position != PlayerController.instance.transform.position)
            // might have to adjust this
        {
            anim.SetInteger("enemyRun", 1);
        } else
        {
            anim.SetInteger("enemyRun", 0);
        }

        if (this.transform.position.x <= PlayerController.instance.transform.position.x)
        {
            // flip sprite
            sprite.flipX = false;
        } else
        {
            sprite.flipX = true;
        }


        if(hp <= 0)
        {
            anim.SetBool("enemyDeath", true);
            Invoke("Die", 1.0f);
            //Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Player")
        {
            isTouchingPlayer = true;
        }

        if(collision.collider.gameObject.name == "AttackOuter")
        {
            hp -= PlayerController.instance.Attack;
            healthBar = (float)hp / (float)maxHP;
            anim.SetTrigger("enemyTakeDamage");
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
