using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    LayerMask linecastMask = 1 << 0 | 1 << 10;
    public List<GameObject> targets = new List<GameObject>();
    // At some point run through lists to see which target they will aim at, rn its just most recent
    // to be targeted, which is fine
    public WeaponManager weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineOfSight();
    }

    void LineOfSight()
    {
        for (int i = 0; i < GameManager.gameManager._activePlayers.Count; i++)
        {
            PlayerController player = GameManager.gameManager._activePlayers[i];

            RaycastHit2D hit = Physics2D.Linecast(transform.position,
                          player.gameObject.transform.position, linecastMask);

            if (hit.collider != null)
            {
                //Debug.Log("Hit layer: " + hit.collider.gameObject.layer);

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
                    AimAt(player.gameObject);
                }
            }
            else Debug.Log("No collider hit.");
        }
    }

    void AimAt(GameObject target)
    {

        Vector2 relativePos = target.transform.position - transform.position;
        float angle = Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg;

        // gets values
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        Quaternion current = transform.rotation;

        // sets the rotation value
        transform.localRotation = Quaternion.Slerp(current, rotation, 5 * Time.deltaTime);

        weaponManager.Shoot(target);
    }
}
