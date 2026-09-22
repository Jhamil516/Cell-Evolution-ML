using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text roundText;
    public TMP_Text timerText;

    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public TMP_Text finalRoundText;

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
        timerText.text =
            "TIEMPO: " + Mathf.CeilToInt(time);
    }

    public void ShowGameOver(int score, int round)
    {
        gameOverPanel.SetActive(true);

        finalScoreText.text =
            "Puntuación: " + score;

        finalRoundText.text =
            "Generaciones sobrevividas: " + round;
    }
}