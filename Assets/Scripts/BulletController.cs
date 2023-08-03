using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            // damage enemy by calling enemys HealthManager()
            //Debug.Log("Hit enemy");
            Destroy(gameObject);
        }
        else
        {
            // richochet sfx
            //Debug.Log("Hit" + collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
