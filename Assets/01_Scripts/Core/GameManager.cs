using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float roundDuration = 10f;
    public AdaptationManager adaptationManager;

    public UIManager uiManager;
    public CellSpawner cellSpawner;
    public Transform cellContainer;

    private float timeRemaining;
    private int currentRound = 1;
    private int score = 0;

    void Start()
    {
        uiManager.UpdateScore(score);

        StartRound();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
        {
            timeRemaining = 0;
        }

        uiManager.UpdateTimer(timeRemaining);

        if (timeRemaining <= 0)
        {
            EndRound();
        }
    }

    void StartRound()
    {
        timeRemaining = roundDuration;

        uiManager.UpdateRound(currentRound);
        uiManager.UpdateTimer(timeRemaining);

        cellSpawner.SpawnCells();

        Debug.Log("Inicia ronda " + currentRound);
    }

    void EndRound()
    {
        int survivors = cellContainer.childCount;

        int eliminated =
            cellSpawner.numberOfCells - survivors;

        Debug.Log(
            "Ronda " + currentRound +
            " | Eliminadas: " + eliminated +
            " | Supervivientes: " + survivors
        );

        // Registrar las células supervivientes
        foreach (Transform child in cellContainer)
        {
            Cell cell = child.GetComponent<Cell>();

            adaptationManager.RegisterExperience(
                cell.cellColor,
                cell.cellSize,
                true
            );
        }

        // Finalizar el aprendizaje de esta generación
        adaptationManager.FinishGeneration();

        // Si no eliminamos ninguna célula,
        // las células ganaron.
        if (eliminated == 0)
        {
            GameOver();
            return;
        }

        ClearCells();

        currentRound++;

        StartRound();
    }
    void ClearCells()
    {
        foreach (Transform cell in cellContainer)
        {
            Destroy(cell.gameObject);
        }
    }
    public void AddScore()
    {
        score++;

        uiManager.UpdateScore(score);
    }
    void GameOver()
    {
        Debug.Log(
            "GAME OVER | Las células lograron sobrevivir completamente."
        );

        uiManager.ShowGameOver(
            score,
            currentRound
        );

        enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}