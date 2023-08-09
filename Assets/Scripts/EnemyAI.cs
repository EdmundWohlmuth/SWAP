using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    LayerMask linecastMask = 1 << 0 | 1 << 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < GameManager.gameManager._activePlayers.Count; i++)
        {
            PlayerController player = GameManager.gameManager._activePlayers[i];

            RaycastHit2D hit = Physics2D.Linecast(transform.position,
                          player.gameObject.transform.position, linecastMask);

            if (hit.collider != null)
            {
                Debug.Log("Hit layer: " + hit.collider.gameObject.layer);

                if (hit.collider.transform.parent != null && hit.collider.transform.parent.gameObject.layer != 10)
                {
                    Debug.DrawLine(transform.position,
                               player.gameObject.transform.position, Color.blue);
                    //Debug.Log(hit.collider.gameObject.layer);
                }
                else
                {

                    Debug.DrawLine(transform.position,
                               player.gameObject.transform.position, Color.red);
                }
            }
            else Debug.Log("No collider hit.");
        }
    }
}
