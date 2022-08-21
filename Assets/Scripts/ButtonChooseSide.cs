using UnityEngine;
using UnityEngine.UI;

public class ButtonChooseSide : MonoBehaviour
{
    GameManager GameManager;
    public Text playerSide;
    private GameObject ChoosePlayerPanel;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ChoosePlayerSide()
    {
        GameManager.SetPlayerSide(playerSide.text);
        Debug.Log("SIDE CHOSEN: " + playerSide.text);

        GameManager.RemoveChoosePlayerPanel();

    }
}
