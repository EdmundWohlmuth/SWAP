using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Refrences")]
    public Camera mainCamera;
    public GameObject crossHair;
    public WeaponManager weaponManager;

    [Header("Keybinds")]
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode aim = KeyCode.Mouse1;
    public KeyCode fire = KeyCode.Mouse0;

    [Header("CharacterStats")]
    public bool isSelected;
    public float movementSpeed;
    public float rotationSpeed;

    [Header("InputSystem")]
    public InputActionReference moveAction;
    public InputActionReference shootAction;

    #region Enable/Disable
    private void OnEnable()
    {
        moveAction.action.Enable();
        shootAction.action.Enable();

        moveAction.action.performed += ctx => MoveCharacter();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
        shootAction.action.Disable();

        moveAction.action.performed -= ctx => MoveCharacter();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
        weaponManager.isAi = false;
        mainCamera = GameManager.mainCamera;
        GameManager.activePlayers.Add(this.GetComponent<PlayerController>());
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            //MoveCharacter();
            AimCharacter();

            if (weaponManager.weaponData.isAutoFire)
            {
                if (Input.GetKey(fire)) weaponManager.Shoot(crossHair);
            }
            else
            {
                if (Input.GetKeyDown(fire)) weaponManager.Shoot(crossHair);
            }

            
        }
        else
        {

        }


    }

    void MoveCharacter()
    {
        //Vector2 direction = moveAction.action.ReadValue<Vector2>();
        //Debug.Log(moveAction.action.ReadValue<Vector2>());
        //transform.position += new Vector3(direction.x, direction.y, 0) * movementSpeed * Time.deltaTime;


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
