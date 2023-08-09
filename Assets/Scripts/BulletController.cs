using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public bool isAi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<Collider2D>());

        if (collision.gameObject.layer == 11)
        {
            // damage enemy by calling enemys HealthManager()
            // Debug.Log("Hit enemy");
            // AI don't deal Freindly fire damage
            if (!isAi) collision.gameObject.GetComponentInParent<HealthController>().TakeDamage(damage);
            //if (!isAi) Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("Hit player");
            if (isAi) collision.gameObject.GetComponent<HealthController>().TakeDamage(damage);
            // deal less damage on freindly fire?
            Destroy(gameObject);           
        }
        else if (collision.gameObject.layer != 9)
        {
            // richochet sfx
            //Debug.Log("Hit" + collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
