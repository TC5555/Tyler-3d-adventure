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
        
            GameObject Weapon = transform.GetChild(0).gameObject;
            transform.DetachChildren();
            Weapon.tag = "Enemy";
            Weapon.transform.SetParent(collision.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0),false);
            Weapon.transform.parent.GetComponent<PawnBT>().equipWeapon = transform.GetChild(0).gameObject;    
            Destroy(gameObject);
            Debug.Break();
        }
       

    }
}
