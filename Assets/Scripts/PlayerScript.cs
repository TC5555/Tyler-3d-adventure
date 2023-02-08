using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float speed = 7.0f;

    public int maxHealth = 10;


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
    float jump;
    float fire;

    GameObject ActiveWeapon;
    WeaponScript WeaponScr;

    float horizontalShoot;
    float verticalShoot;

    Animator animator;

    Vector2 moveDirection = new Vector2(1, 0);
    Vector2 lookDirection = new Vector2(1, 0);
    bool lookHeld;
    bool moveHeld;
    bool grounded;

    public int weaponChildrenStart;

    int currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

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
        fire = Input.GetAxis("Fire");
        jump = Input.GetAxis("Jump");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.5f))
        {
            moveHeld = true;
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }
        else
        {
            moveHeld = false;
        }

        if (!Mathf.Approximately(jump, 0.0f) && grounded)
        {
            Debug.Log("jump");
            rigidbody.AddForce(new Vector3(0, rigidbody.mass * Mathf.Sqrt(2*Physics.gravity.magnitude*jumpHeight), 0), ForceMode.Impulse);
            grounded = false;
        }




        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 position = rigidbody.position;


        float y = Input.GetAxis("Mouse X") * 4;
        rotX += Input.GetAxis("Mouse Y") * 4;

        rotX = Mathf.Clamp(rotX, -90, 90);



        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);

        transform.GetChild(0).eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        ActiveWeapon.transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        Vector3 movement = Vector3.ClampMagnitude(transform.GetChild(0).forward * vertical + transform.GetChild(0).right * horizontal, 1);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        WeaponScr.fire = fire;


    }

    private void OnCollisionStay(Collision collision)
    {      
        if (!grounded && Mathf.Approximately(rigidbody.velocity.y, 0.0f) && collision.gameObject.tag == "Terrain")
        {
           // Debug.Log(rigidbody.velocity.y);
            grounded = true;
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
