using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameOptions : MonoBehaviour
{
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
