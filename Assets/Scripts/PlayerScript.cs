using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float speed = 7.0f;

    public int maxHealth = 100;


    // public ParticleSystem DodgeParticles;
    //  public ParticleSystem DamageParticles;
    //public ParticleSystem HealParticles;

    public float currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    private float rotX;

    public float jumpHeight;

    Rigidbody rigidbody;
    float horizontal;
    float vertical;
    bool jump;
    float fire;

    bool dodge;
    bool airDodge;
    float dodgeTimer = 0;
    public float dodgeSpeed;
    public float dodgeCooldown;
    public float playerSpeed;

    GameObject ActiveWeapon;
    WeaponScript WeaponScr;

    float horizontalShoot;
    float verticalShoot;

    Animator animator;

    Vector3 moveDirection;
    bool changedDirection;

    bool lookHeld;
    bool moveHeld;
    bool grounded;
    bool doubleJump;

    public int weaponChildrenStart;

    int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
      

        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;

        ActiveWeapon = transform.GetChild(weaponChildrenStart).gameObject;
        ActiveWeapon.SetActive(true);
        currentWeapon = weaponChildrenStart;

        WeaponScr = ActiveWeapon.GetComponent<WeaponScript>();

        

    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDirection = Vector3.ClampMagnitude(transform.GetChild(0).forward * vertical + transform.GetChild(0).right * horizontal, 1);


        fire = Input.GetAxis("Fire");
        jump = Input.GetButtonDown("Jump");
        dodge = Input.GetButtonDown("Dodge");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.5f))
        {
            moveHeld = true;
        }
        else
        {
            moveHeld = false;
        }

        if (jump)
        {
            if (grounded)
            {
                Debug.Log("jump");
                rigidbody.AddForce(new Vector3(0, rigidbody.mass * Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpHeight), 0), ForceMode.Impulse);
                grounded = false;
            }
            else if (doubleJump)
            {
                Debug.Log("doubleJump");
                rigidbody.AddForce(new Vector3(0, rigidbody.mass * Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpHeight), 0), ForceMode.Impulse);
                doubleJump = false;
            }
        }
        if (dodgeTimer < 0)
        {
            if (dodge)
            {
                if (grounded)
                {
                    Debug.Log("dodge");
                    rigidbody.AddForce(moveDirection * dodgeSpeed, ForceMode.Impulse);
                    dodgeTimer = dodgeCooldown;
                    rigidbody.drag = 0.95f;
                }
                else if (airDodge)
                {
                    Debug.Log("airDodge");
                    rigidbody.AddForce(moveDirection * dodgeSpeed * 3/4, ForceMode.Impulse);
                    airDodge = false;
                    dodgeTimer = dodgeCooldown;
                    rigidbody.drag = 0.95f;
                }
            }
            else
            {
                rigidbody.drag = .6f;
            }
        }
        dodgeTimer -= Time.deltaTime;
      


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }


        float y = Input.GetAxis("Mouse X") * 4;
        rotX += Input.GetAxis("Mouse Y") * 4;

        rotX = Mathf.Clamp(rotX, -90, 90);



        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);

        transform.GetChild(0).eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
        transform.GetChild(3).eulerAngles = new Vector3(-rotX, transform.GetChild(3).rotation.y, 0);

        ActiveWeapon.transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }

    void FixedUpdate()
    {
             //transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        if (grounded && Mathf.Sqrt(rigidbody.velocity.x * rigidbody.velocity.x + rigidbody.velocity.z * rigidbody.velocity.z) < playerSpeed)
        {
            rigidbody.velocity = new Vector3(playerSpeed * moveDirection.x, rigidbody.velocity.y, playerSpeed * moveDirection.z);
        }
        Debug.Log(Mathf.Sqrt(rigidbody.velocity.x * rigidbody.velocity.x + rigidbody.velocity.z * rigidbody.velocity.z));
    }

    private void OnCollisionStay(Collision collision)
    {      
        if (!grounded && rigidbody.velocity.y < 0.5f && collision.gameObject.tag == "Terrain")
        {
           // Debug.Log(rigidbody.velocity.y);
            grounded = true;
            doubleJump = true;
            airDodge = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            grounded = false;
        }
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

    }

}
