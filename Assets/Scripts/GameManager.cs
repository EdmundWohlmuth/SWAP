using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Refrences")]
    public static GameManager gameManager;
    public static Camera mainCamera;
    public int selectedCharacter;

    [Header("Lists")]
    public static List<PlayerController> activePlayers = new List<PlayerController>();

    public List<PlayerController> _activePlayers = new List<PlayerController>();
    public List<WeaponData> weaponType = new List<WeaponData>();

    [Header("Keybinds")]
    public InputActionReference swapAction;
    /*public KeyCode nextSWAP = KeyCode.RightBracket;
    public KeyCode lastSWAP = KeyCode.LeftBracket;*/

    private void Awake()
    {
        mainCamera = Camera.main;

        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gameManager != this && gameManager != null)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        swapAction.action.Enable();

        swapAction.action.performed += ctx => CharSelect();
    }
    private void OnDisable()
    {
        swapAction.action.Disable();

        swapAction.action.performed -= ctx => CharSelect();
    }

    void Start()
    {
        activePlayers[0].isSelected = true;
    }


    void CharSelect()
    {
        //update list
        if (_activePlayers != activePlayers)
        {
            _activePlayers = activePlayers;
        }

        // if (isInGameplay)
        // select current playable unit

        if (swapAction.action.ReadValue<float>() > 0) NextCharacter(true);
        else if (swapAction.action.ReadValue<float>() < 0) NextCharacter(false);
    }

    public void NextCharacter(bool value)
    {
        foreach (PlayerController controller in activePlayers)
        {
            controller.isSelected = false;
        }


        if (value) selectedCharacter++;
        else selectedCharacter--;

        if (selectedCharacter >= activePlayers.Count) selectedCharacter = 0;
        else if (selectedCharacter < 0) selectedCharacter = activePlayers.Count - 1;

        activePlayers[selectedCharacter].isSelected = true;
        activePlayers[selectedCharacter].SwitchedTo();
    }
}
