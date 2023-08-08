using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (PlayerController player in GameManager.gameManager._activePlayers)
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position,
                                      player.gameObject.transform.position, 11);

            if (hit.collider.gameObject.layer != 10)
            {
                Debug.DrawLine(transform.position,
                           player.gameObject.transform.position, Color.blue);
                Debug.Log(hit.collider.gameObject.layer);
            }
            else if (hit.collider.gameObject.layer == 10)
            {
                Debug.DrawLine(transform.position,
                           player.gameObject.transform.position, Color.red);
            }
        }*/

        for (int i = 0; i < GameManager.gameManager._activePlayers.Count; i++)
        {
            PlayerController player = GameManager.gameManager._activePlayers[i];

            RaycastHit2D hit = Physics2D.Linecast(transform.position,
                          player.gameObject.transform.position, 11);

            if (hit.collider.gameObject.layer != 10)
            {
                Debug.DrawLine(transform.position,
                           player.gameObject.transform.position, Color.blue);
                //Debug.Log(hit.collider.gameObject.layer);
            }
            else if (hit.collider.gameObject.layer == 10)
            {
                Debug.DrawLine(transform.position,
                           player.gameObject.transform.position, Color.red);
            }
        }
    }

    public void Aim()
    {

    }

}
