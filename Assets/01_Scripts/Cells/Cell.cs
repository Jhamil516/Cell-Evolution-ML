using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private AdaptationManager adaptationManager;

    public Color cellColor = Color.white;
    public float cellSize = 1f;
    public bool isAlive = true;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        adaptationManager =
            FindFirstObjectByType<AdaptationManager>();
    }

    public void SetCharacteristics(Color color, float size)
    {
        cellColor = color;
        cellSize = size;

        spriteRenderer.color = cellColor;
        transform.localScale = Vector3.one * cellSize;
    }

    void OnMouseDown()
    {
        Die();
    }

    void Die()
    {
        isAlive = false;

        adaptationManager.RegisterExperience(
            cellColor,
            cellSize,
            false
        );

        Destroy(gameObject);
    }
}