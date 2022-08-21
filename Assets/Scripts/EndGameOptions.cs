using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameOptions : MonoBehaviour
{
    public void RestartGame()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
