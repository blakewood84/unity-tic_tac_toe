using UnityEngine;
using UnityEngine.UI;

public class WinnerPanel : MonoBehaviour
{
    public Text WinningPlayer;

    public void AssignWinner(string winner)
    {
        WinningPlayer.text = winner;
    }

}
