using System.Collections.Generic;
using UnityEngine;

public class AdaptationManager : MonoBehaviour
{
    public List<CellExperience> experiences = new List<CellExperience>();

    // Qué tanto puede variar una característica heredada.
    public float colorMutation = 0.15f;
    public float sizeMutation = 0.15f;

    public void RegisterExperience(Color color, float size, bool survived)
    {
        CellExperience experience =
            new CellExperience(color, size, survived);

        experiences.Add(experience);

        Debug.Log(
            "Experiencia | Tamaño: " +
            size.ToString("F2") +
            " | Sobrevivió: " +
            survived
        );
    }

    public CellExperience GetAdaptedCharacteristics(
        float minSize,
        float maxSize)
    {
        List<CellExperience> survivors =
            experiences.FindAll(e => e.survived);

        // Si todavía no tenemos supervivientes,
        // exploramos con características aleatorias.
        if (survivors.Count == 0)
        {
            return CreateRandomCharacteristics(
                minSize,
                maxSize
            );
        }

        // Elegimos una experiencia exitosa.
        CellExperience parent =
            survivors[Random.Range(0, survivors.Count)];

        // Mutación del color heredado.
        Color newColor = new Color(
            Mathf.Clamp01(
                parent.color.r +
                Random.Range(-colorMutation, colorMutation)
            ),
            Mathf.Clamp01(
                parent.color.g +
                Random.Range(-colorMutation, colorMutation)
            ),
            Mathf.Clamp01(
                parent.color.b +
                Random.Range(-colorMutation, colorMutation)
            )
        );

        // Mutación del tamaño heredado.
        float newSize = Mathf.Clamp(
            parent.size +
            Random.Range(-sizeMutation, sizeMutation),
            minSize,
            maxSize
        );

        return new CellExperience(
            newColor,
            newSize,
            false
        );
    }

    CellExperience CreateRandomCharacteristics(
        float minSize,
        float maxSize)
    {
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );

        float randomSize =
            Random.Range(minSize, maxSize);

        return new CellExperience(
            randomColor,
            randomSize,
            false
        );
    }
}