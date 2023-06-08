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
    [SerializeField] GameObject statsObject;
    [SerializeField] private Animator anim;
    // anim is used to trigger the different animations

    private HealthBarController healthBarController;
    private StatController statController;

    private int attack;
    private int defense;
    private int speed = 8;

    //speed getter and setter
    public int Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarController = healthBarObject.GetComponentInChildren<HealthBarController>();
        statController = statsObject.GetComponent<StatController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
            statController.setAttackText(5);
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

    }

    public void TakeDamage(int damage)
    {
        //TODO: Add a conditional for IFrames. Like If not invinicble then do this down below, otherwise nothing happens
        currentHealth -= damage;
        healthBarController.SetHealth(currentHealth);
        anim.SetTrigger("Hurt");
    }

}
