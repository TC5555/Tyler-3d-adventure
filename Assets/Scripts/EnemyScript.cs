using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;


    public int maxHealth;

    public float currentHealth;

    protected Color32 colorVal = new Color32(255, 255, 255, 255);

    protected new Rigidbody2D rigidbody2D;
    public bool alive = true;
    public GameObject pickupPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
           // gameObject.GetComponent<Renderer>().material.color = colorVal;
           // DeathParticles.Play();
           // if (gameObject.tag != "SpawnedEnemy")
          //  {
           //     DropHealth();
         //   }
           // alive = false;
      //      rigidbody2D.simulated = false;

       // }
       // else
        //{


     //       colorVal = new Color32(255, 0, 0, 255);
     //   }
//
   


