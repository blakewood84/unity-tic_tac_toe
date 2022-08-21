using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    const string PlayerX = "X";
    const string PlayerO = "0";

    private Color XColor = new Color(0, 0, 255, 255);
    private Color OColor = Color.red;

    int[,] winningConditions = new int[8, 3]
    {
        // Horizontal Rows
        {0,1,2},
        {3,4,5},
        {6,7,8},
        // Vertical Rows
        {0,3,6},
        {1,4,7},
        {2,5,8},
        // Diagonal Rows
        {0,4,8},
        {2,4,6},
    };

    public GridSpace[] gridSpaces;
    public GameObject ChoosePlayerPanel; // Assigned via Unity
    public GameObject WinnerPanel; // Assigned via Unity
    public GameObject GameOptionsPanel; // Assigned via Unity, for End / Restart
    public GameObject DrawPanel; // Assigned via Unity
    private GameObject StartButton;
    private GameObject Canvas;
    private string playerSide;
    private string computerSide;

    // Allows the player to choose X or O
    public string GetPlayerSide()
    {
        return playerSide;
    }

    public Color GetPlayerColor(string side)
    {
        return (side.Equals(PlayerX)) ? XColor : OColor;
    }

    public void SetPlayerSide(string side)
    {
        playerSide = side;
        computerSide = (side.Equals(PlayerX)) ? "O" : "X";
    }

    public void StartGame()
    {
        Debug.Log("Game Started!");

        // Remove Start Button
        StartButton = GameObject.Find("StartButton");
        StartButton.SetActive(false);

        // Await till Side Choose Panel is removed
        ChoosePlayerPanel.SetActive(true);

    }

    public void RemoveChoosePlayerPanel()
    {
        ChoosePlayerPanel.SetActive(false);

        // Enable buttons for game after player has been chosen
        for (int i = 0; i < gridSpaces.Length; i++)
        {
            gridSpaces[i].button.interactable = true;
        }
    }

    // This checks which plays can be made by the computer, or if there are no plays left (Draw)
    private List<int> GetUnplayedGridSpaces()
    {
        List<int> unplayedGridSpaces = new List<int>();

        // Search to see which numbers can be played (0-8)
        for (int i = 0; i < gridSpaces.Length; i++)
        {
            if (gridSpaces[i].buttonText.text != playerSide && gridSpaces[i].buttonText.text != computerSide)
            {
                unplayedGridSpaces.Add(i);
            }
        }
        return unplayedGridSpaces;
    }

    private bool CheckForGameWinner(string side)
    {
        // loop through each set of Winning Equations
        // if one is true, return true

        for (int x = 0; x < winningConditions.GetLength(0); x++)
        {
            // Get winning indexes for row
            List<int> row = new List<int>();
            for (int j = 0; j < winningConditions.GetLength(1); j++)
            {
                row.Add(winningConditions[x, j]);
            }

            // Check the GridSpaces for the winner
            List<GridSpace> spaces = new List<GridSpace>();
            for (int i = 0; i < row.Count; i++)
            {
                int index = row[i];
                spaces.Add(gridSpaces[index]);
            }

            bool winner = spaces.TrueForAll((e) => e.buttonText.text == side);

            if (winner)
            {
                // Highlight winning tiles
                foreach (GridSpace space in spaces)
                {
                    space.buttonText.color = Color.magenta;

                }

                return true;
            }
        }

        // if not return false
        return false;
    }

    // End's Human Player's turn logic
    public void EndPlayerTurn()
    {
        bool winner = CheckForGameWinner(playerSide);

        if (winner)
        {
            ShowWinnerPanel(playerSide);
            return;
        }

        List<int> unplayedGridSpaces = GetUnplayedGridSpaces();

        // Check for Draw
        if (unplayedGridSpaces.Count == 0)
        {
            ShowDrawPanel();
            return;
        }

        RunComputerTurn();
    }

    // Computer AI Logic
    private void RunComputerTurn()
    {
        Debug.Log("Computer's Turn!");

        List<int> unplayedGridSpaces = GetUnplayedGridSpaces();

        if (unplayedGridSpaces.Count == 0)
        {
            // Game is Draw, End Game;
            ShowDrawPanel();
            return;
        }

        // Choose random number from available GridSpaces
        int randomIndex = Random.Range(0, unplayedGridSpaces.Count);
        int randomGridSpace = unplayedGridSpaces[randomIndex];

        // Assign button attributes and disable button
        GridSpace space = gridSpaces[randomGridSpace];
        space.buttonText.text = computerSide;
        space.button.interactable = false;

        Color computerColor = GetPlayerColor(computerSide);
        space.buttonText.color = computerColor;

        bool winner = CheckForGameWinner(computerSide);

        if (winner)
        {
            // Throw Game Over Panel
            ShowWinnerPanel(computerSide);
        }
    }

    // Shows a Panel that shows which player has won (X or O)
    private void ShowWinnerPanel(string winner)
    {
        Debug.Log("Winner! " + winner);
        WinnerPanel.SetActive(true);
        WinnerPanel.GetComponent<WinnerPanel>().AssignWinner(winner);

        GameOptionsPanel.SetActive(true);

        // Shutdown Game
        for (int i = 0; i < gridSpaces.Length; i++)
        {
            gridSpaces[i].button.interactable = false;
        }
    }

    // Shows a Panel declaring game is tied or (Draw)
    private void ShowDrawPanel()
    {
        Debug.Log("Game is a Draw!");
        DrawPanel.SetActive(true);
        GameOptionsPanel.SetActive(true);

    }

}
