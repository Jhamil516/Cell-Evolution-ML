using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public GameObject cellPrefab;
    public Transform cellContainer;

    public int numberOfCells = 10;

    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -4f;
    public float maxY = 3.5f;

    public float minSize = 0.7f;
    public float maxSize = 1.3f;

    void Start()
    {
        SpawnCells();
    }

    void SpawnCells()
    {
        for (int i = 0; i < numberOfCells; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 randomPosition =
                new Vector3(randomX, randomY, 0);

            GameObject newCell = Instantiate(
                cellPrefab,
                randomPosition,
                Quaternion.identity,
                cellContainer
            );

            float randomSize =
                Random.Range(minSize, maxSize);

            Color randomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );

            Cell cell =
                newCell.GetComponent<Cell>();

            cell.SetCharacteristics(
                randomColor,
                randomSize
            );
        }
    }
}