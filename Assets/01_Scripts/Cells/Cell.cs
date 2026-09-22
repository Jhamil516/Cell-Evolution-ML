using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Color cellColor = Color.white;
    public float cellSize = 1f;
    public bool isAlive = true;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        Debug.Log(
            "Celula eliminada | Color: " +
            cellColor +
            " | Tamaño: " +
            cellSize
        );

        Destroy(gameObject);
    }
}