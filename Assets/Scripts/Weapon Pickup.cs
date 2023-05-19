using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<PlayerScript>().AddWeapon();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.AddComponent<Transform.getChild(0)>();
        }
    }
}
