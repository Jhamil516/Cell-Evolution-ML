using UnityEngine;

[System.Serializable]
public class CellExperience
{
    public Color color;
    public float size;
    public bool survived;

    public CellExperience(Color color, float size, bool survived)
    {
        this.color = color;
        this.size = size;
        this.survived = survived;
    }
}