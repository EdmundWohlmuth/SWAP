using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Refrences")]
    public static GameManager gameManager;
    public static Camera mainCamera;
    public int selectedCharacter;

    [Header("Lists")]
    public static List<PlayerController> activePlayers = new List<PlayerController>();

    public List<PlayerController> _activePlayers = new List<PlayerController>();

    [Header("Keybinds")]
    public KeyCode nextSWAP = KeyCode.RightBracket;
    public KeyCode lastSWAP = KeyCode.LeftBracket;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //update list
        if (_activePlayers != activePlayers)
        {
            _activePlayers = activePlayers;
        }

        // if (isInGameplay)
        // select current playable unit
        if (Input.GetKeyDown(nextSWAP))
        {
            NextCharacter();
        }
        else if (Input.GetKeyDown(lastSWAP))
        {
            LastCharacter();
        }
    }

    public void NextCharacter()
    {
        selectedCharacter++;
        if (selectedCharacter >= activePlayers.Count) selectedCharacter = 0;
        SelectCharacter();
    }
    void LastCharacter()
    {
        selectedCharacter--;
        if (selectedCharacter < 0) selectedCharacter = activePlayers.Count-1;
        SelectCharacter();
    }
    void SelectCharacter()
    {
        Debug.Log(activePlayers.Count);
        for (int i = 0; i < activePlayers.Count; i++)
        {
            if (selectedCharacter == i)
            {
                activePlayers[i].isSelected = true;
            }
            else activePlayers[i].isSelected = false;
        }
    }
}
