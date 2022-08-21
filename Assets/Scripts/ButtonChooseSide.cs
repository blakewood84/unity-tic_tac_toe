using UnityEngine;
using UnityEngine.UI;

public class ButtonChooseSide : MonoBehaviour
{

    public Text playerSide;
    private GameObject ChoosePlayerPanel;
    private GameManager GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ChoosePlayerSide()
    {
        Debug.Log("You've Chosen: " + playerSide.text);
        GameManager.SetPlayerSide(playerSide.text);
        GameManager.RemoveChoosePlayerPanel();

    }
}
