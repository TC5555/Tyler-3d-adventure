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
   

    Rigidbody rigidbody;
    float horizontal;
    float vertical;
    float jump;

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
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
     
        currentHealth = maxHealth;
       
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        jump = Input.GetAxis("Jump");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveHeld = true;
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }
        else
        {
            moveHeld = false;
        }

       if(jump > .1 && grounded)
        {
            rigidbody.AddForce(new Vector3(0, 80, 0));
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

       

        Vector3 movement = Vector3.ClampMagnitude(transform.GetChild(0).forward * vertical + transform.GetChild(0).right * horizontal,1);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);


       // rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
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

}
