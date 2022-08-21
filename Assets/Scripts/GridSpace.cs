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
        string playerSide = GameManager.GetPlayerSide();
        Color playerColor = GameManager.GetPlayerColor(playerSide);

        buttonText.text = playerSide;
        buttonText.color = playerColor;
        button.interactable = false;

        GameManager.EndPlayerTurn();
    }

    // Initializes Game Manager when Game Starts
    public void Init()
    {
        button.interactable = false;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

}
