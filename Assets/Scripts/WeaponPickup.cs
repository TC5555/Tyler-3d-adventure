using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
  
    void OnColliderEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerScript>().AddWeapon();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            transform.GetChild(0).tag = "Enemy";
            transform.parent.GetComponent<PawnBT>().equipWeapon = transform.GetChild(0).gameObject;
            transform.GetChild(0).parent = collision.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
            Destroy(gameObject);
        }
    }
}
