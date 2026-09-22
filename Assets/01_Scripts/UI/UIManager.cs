using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text roundText;
    public TMP_Text timerText;

    public void UpdateScore(int score)
    {
        scoreText.text = "PUNTOS: " + score;
    }

    public void UpdateRound(int round)
    {
        roundText.text = "RONDA: " + round;
    }

    public void UpdateTimer(float time)
    {
        timerText.text = "TIEMPO: " + Mathf.CeilToInt(time);
    }
}