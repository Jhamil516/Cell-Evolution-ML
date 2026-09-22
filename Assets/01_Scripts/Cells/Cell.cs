using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private AdaptationManager adaptationManager;
    private GameManager gameManager;

    public Color cellColor = Color.white;
    public float cellSize = 1f;
    public bool isAlive = true;
    [Header("Sonidos")]
    public AudioClip deathSFX;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        adaptationManager = FindFirstObjectByType<AdaptationManager>();

        gameManager = FindFirstObjectByType<GameManager>();
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

        gameManager.AddScore();

        AudioManager.instance.PlaySFX(
            deathSFX,
            1f,
            Random.Range(0.9f, 1.1f)
        );

        Destroy(gameObject);
    }
}