using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownedDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 100;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
