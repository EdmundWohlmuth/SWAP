using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Refrences")]
    public Camera mainCamera;
    public GameObject crossHair;

    [Header("Keybinds")]
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode aim = KeyCode.Mouse1;

    [Header("CharacterStats")]
    public bool isSelected;
    public float movementSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameManager.mainCamera;
        GameManager.activePlayers.Add(this.GetComponent<PlayerController>());
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            MoveCharacter();
            AimCharacter();
        }
        else
        {

        }
    }

    void MoveCharacter()
    {
        if (Input.GetKey(forward))
        {
            transform.position += new Vector3(0, 1, 0) * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(backward))
        {
            transform.position -= new Vector3(0, 1, 0) * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(left))
        {
            transform.position -= new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            transform.position += new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
        }
    }
    void AimCharacter()
    {
        if (Input.GetKey(aim))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            crossHair.transform.position = mousePosition;

            Vector2 relativePos = crossHair.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg;

            // gets values
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
            Quaternion current = transform.rotation;

            // sets the rotation value
            transform.localRotation = Quaternion.Slerp(current, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
