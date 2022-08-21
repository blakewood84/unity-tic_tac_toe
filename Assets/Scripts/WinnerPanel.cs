using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerPanel : MonoBehaviour
{
    public Text winningPlayer;

    public void AssignWinner(string winner)
    {
        winningPlayer.text = winner;
    }

    private void RestartGame()
    {
        //Get current scene name
        string scene = SceneManager.GetActiveScene().name;
        //Load it
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void EndGame()
    {
        Application.Quit();
    }

}
