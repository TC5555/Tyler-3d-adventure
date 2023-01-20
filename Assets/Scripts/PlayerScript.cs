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

   

    Rigidbody rigidbody;
    float horizontal;
    float vertical;

    float horizontalShoot;
    float verticalShoot;

    Animator animator;

    Vector2 moveDirection = new Vector2(1, 0);
    Vector2 lookDirection = new Vector2(1, 0);
    bool lookHeld;
    bool moveHeld;

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

     //   horizontalShoot = Input.GetAxis("HorizontalShoot");
      //  verticalShoot = Input.GetAxis("VerticalShoot");

        Vector2 move = new Vector2(horizontal, vertical);


        Vector2 shoot = new Vector2(horizontalShoot, verticalShoot);

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

        /*if (!Mathf.Approximately(shoot.x, 0.0f) || !Mathf.Approximately(shoot.y, 0.0f))
        {

            lookHeld = true;
            lookDirection.Set(shoot.x, shoot.y);
            lookDirection.Normalize();
        }
        else
        {

            lookHeld = false;
        }*/

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


        position.x += speed * horizontal * Time.deltaTime;
        position.z += speed * vertical * Time.deltaTime;

        rigidbody.MovePosition(position);
    }

}
