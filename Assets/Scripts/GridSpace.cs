using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    private GameManager GameManager;

    private void Start()
    {
        Init();
    }

    // Sets the Button to disabled, and the Text to the player (X or O)
    public void SetSpace()
    {
        buttonText.text = GameManager.GetPlayerSide();
        button.interactable = false;
        // Checks to see if player has won
        GameManager.EndPlayerTurn();
    }

    // Initializes Game Manager when Game Starts
    public void Init()
    {
        Debug.Log("Init!");
        button.interactable = false;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

}
