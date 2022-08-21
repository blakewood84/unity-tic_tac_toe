using UnityEngine;
using UnityEngine.UI;

public class WinnerPanel : MonoBehaviour
{
    public Text winningPlayer;

    public void AssignWinner(string winner)
    {
        winningPlayer.text = winner;
    }

}
