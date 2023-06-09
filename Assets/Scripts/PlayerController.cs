using System.Collections;
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
    [SerializeField] private Collider2D playerCollider;
    // Anim is used to trigger the different animations

    private HealthBarController healthBarController;

    // Dash Stuff
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashDuration = .25f;
    [SerializeField] float dashCooldown = 1f;
    [SerializeField] float dashSlosh = .25f;
    bool isDashing;
    bool canDash = true;

    private int attack;
    private int defense;
    private int speed;
    //Audio
    public AudioClip SwingAudio;
    public AudioClip DashAudio;
    public AudioClip GetHurt;
    public AudioSource audioSource;
    // Stats getters and setters
    public int Speed { get => speed; set => speed = value; }
    public int Attack { get => attack; set => attack = value; }

    public int Defense { get => defense; set => defense = value; }
    public float Health { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarController = healthBarObject.GetComponentInChildren<HealthBarController>();
        audioSource=GetComponent<AudioSource>();
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

        // While dashing we can't do anything
        if(isDashing)
        {
            return;
        }

        if(timeSinceLastAttack >= .33f)
        {
            AttackCenter.SetActive(false);
        }
        
        // Calculating the proper angle for the attack
        Vector3 rotation = AttackCenter.transform.localEulerAngles;
        rotation.z = (Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - AttackCenter.transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - AttackCenter.transform.position.x) * Mathf.Rad2Deg) - 90.0f;
        AttackCenter.transform.localEulerAngles = rotation;

        // Attack if left click
        if (Input.GetButtonDown("Fire1") && !AttackCenter.activeSelf)
        {
            PlayerAttack();
            audioSource.PlayOneShot(SwingAudio,50);
        }
        
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 playerPos = this.GetComponentInParent<Transform>().position;
        if (mousePos.x >= playerPos.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        } 
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        // Copied from obscura (zachary): feel free to replace with different/better input system
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // Debug.Log(movementDirection);
        rb.velocity=this.GetComponent<MovePlayer>().MovePlayerFunction(movementDirection,speed); // Zach's complex move code
        // rb.velocity = new Vector2(movementDirection.x * speed, movementDirection.y * speed); // Ty's basic move code

        // Debug.Log(speed);

        float min = 0.1f;
        if (Mathf.Abs(movementDirection.x) >= min || Mathf.Abs(movementDirection.y) >= min)
        {
            anim.SetInteger("RunSpeed", 1);
        }
        else
        {
            anim.SetInteger("RunSpeed", 0);
        }

        // Dash when player hits space
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash(movementDirection));
            audioSource.PlayOneShot(DashAudio);
        }
    }

    public void TakeDamage(int damage)
    {
        // TODO: Add a conditional for IFrames. Like If not invinicble then do this down below, otherwise nothing happens
        if (timeSinceLastHit < 1f)
        {
            return;
        }

        timeSinceLastHit = 0f;
        // Can't allow players to heal if their defense is too high
        // Also set minimum damage so you can't just facetank every enemy
        currentHealth -= (defense - damage > -5) ? 5 : (damage - defense);
        healthBarController.SetHealth(currentHealth);
        audioSource.PlayOneShot(GetHurt);
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Death");
            //     // Call death state or scene or whatever it is.
        //     // First stop time.
        //     Time.timeScale = 0f;
        //     combatRoomController.DisplayLoseScreen();
            
        //     /*//Temporary, we don't actually want to KILL HIM
        //     // NOTE: Could deactivate the player instead so the playercontroller doesn't get deleted
        //     Destroy(gameObject);*/
        }
    }

    public void PlayerAttack()
    {
        timeSinceLastAttack = 0f;
        anim.SetTrigger("Attack");
        StartCoroutine(SetAttackCenter());

    }

    private IEnumerator SetAttackCenter()
    {
        AttackCenter.SetActive(true);
        yield return new WaitForSeconds(1.0f);
    }

    //Dash mechanic learned from this video
    //https://www.youtube.com/watch?v=VWaiU7W5HdE
    private IEnumerator Dash(Vector2 movementDirection)
    {
        canDash = false;
        isDashing = true;
        playerCollider.enabled = false;
        rb.velocity = new Vector2(movementDirection.x * dashSpeed, movementDirection.y * dashSpeed);
        Debug.Log(rb.velocity);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashSlosh);
        playerCollider.enabled = true;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
