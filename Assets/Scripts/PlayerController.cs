using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Controller for the player
 *  Handles movement, attacking, settings stats and health
 *  Consider splitting into multiple classes if it grows too large
 */
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] GameObject healthBarObject;
    [SerializeField] private Animator anim;
    private float timeSinceLastHit = 0f;
    private float timeSinceLastAttack = 0f;
    [SerializeField] private GameObject AttackCenter;
    // anim is used to trigger the different animations

    private HealthBarController healthBarController;
    private CombatRoomController combatRoomController;

    private int attack;
    private int defense;
    private int speed;

    //stats getters and setters
    public int Speed { get => speed; set => speed = value; }
    public int Attack { get => attack; set => attack = value; }

    public int Defense { get => defense; set => defense = value; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarController = healthBarObject.GetComponentInChildren<HealthBarController>();

        // Stats retrieved from saved values
        attack = PlayerPrefs.GetInt("Attack");
        defense = PlayerPrefs.GetInt("Defense");
        speed = PlayerPrefs.GetInt("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        timeSinceLastHit += Time.deltaTime;

        if(timeSinceLastAttack >= .25f)
        {
            AttackCenter.SetActive(false);
        }
        
        //calculating the proper angle for the attack
        Vector3 rotation = AttackCenter.transform.localEulerAngles;
        rotation.z = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - AttackCenter.transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - AttackCenter.transform.position.x) * Mathf.Rad2Deg;
        AttackCenter.transform.localEulerAngles = rotation;

        //Attack if left click
        if (Input.GetButton("Fire1") && !AttackCenter.activeSelf)
        {
            PlayerAttack();
        }

        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x >= (Screen.width/2.0))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        } 
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        //copied from obscura (zachary): feel free to replace with different/better input system
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        this.GetComponent<MovePlayer>().MovePlayerFunction(movementDirection);

    }

    public void TakeDamage(int damage)
    {
        //TODO: Add a conditional for IFrames. Like If not invinicble then do this down below, otherwise nothing happens
        if (timeSinceLastHit < 1f)
        {
            return;
        }

        timeSinceLastHit = 0f;
        //Can't allow players to heal if their defense is too high
        currentHealth -= (defense >= damage) ? 0 : (damage - defense);
        healthBarController.SetHealth(currentHealth);
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            // Call death state or scene or whatever it is.
            // First stop time.
            Time.timeScale = 0f;
            combatRoomController.DisplayLoseScreen();
            
            /*//Temporary, we don't actually want to KILL HIM
            // NOTE: Could deactivate the player instead so the playercontroller doesn't get deleted
            Destroy(gameObject);*/
        }
    }

    public void PlayerAttack()
    {
        timeSinceLastAttack = 0f;
        AttackCenter.SetActive(true);
        anim.SetTrigger("Attack");
    }

}
