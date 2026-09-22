using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public AdaptationManager adaptationManager;
    public GameObject cellPrefab;
    public Transform cellContainer;

    public int numberOfCells = 10;

    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -4f;
    public float maxY = 3.5f;

    public float minSize = 0.7f;
    public float maxSize = 1.3f;

    public void SpawnCells()
    {
        for (int i = 0; i < numberOfCells; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 randomPosition = new Vector3(
                randomX,
                randomY,
                0
            );

            GameObject newCell = Instantiate(
                cellPrefab,
                randomPosition,
                Quaternion.identity,
                cellContainer
            );

            CellExperience characteristics =
            adaptationManager.GetAdaptedCharacteristics(
                minSize,
                maxSize
            );

            Cell cell = newCell.GetComponent<Cell>();

            cell.SetCharacteristics(
                characteristics.color,
                characteristics.size
            );
        }
    }
}