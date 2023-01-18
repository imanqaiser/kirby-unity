using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;
    public float hitEffectTime = 5.0f;
    private Vector3 originalScale;
    private void Start()
    {
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
    public void TakeHit()
    {
        transform.localScale = originalScale * 0.35f;
        Invoke("RemoveEffect", hitEffectTime);
    }
    private void RemoveEffect()
    {
        transform.localScale = originalScale;

    }
}
