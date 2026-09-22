using System.Collections.Generic;
using UnityEngine;

public class AdaptationManager : MonoBehaviour
{
    public List<CellExperience> currentGeneration =
        new List<CellExperience>();

    public List<CellExperience> previousSurvivors =
        new List<CellExperience>();

    public float colorMutation = 0.15f;
    public float sizeMutation = 0.15f;

    [Range(0f, 1f)]
    public float explorationRate = 0.15f;

    public void RegisterExperience(
        Color color,
        float size,
        bool survived)
    {
        CellExperience experience =
            new CellExperience(color, size, survived);

        currentGeneration.Add(experience);

        Debug.Log(
            "Experiencia | Tamaño: " +
            size.ToString("F2") +
            " | Sobrevivió: " +
            survived
        );
    }

    public void FinishGeneration()
    {
        previousSurvivors.Clear();

        foreach (CellExperience experience in currentGeneration)
        {
            if (experience.survived)
            {
                previousSurvivors.Add(experience);
            }
        }

        Debug.Log(
            "Generación finalizada | Supervivientes usados para aprender: "
            + previousSurvivors.Count
        );

        currentGeneration.Clear();
    }

    public CellExperience GetAdaptedCharacteristics(
        float minSize,
        float maxSize)
    {
        // Si no tenemos padres, la célula será aleatoria.
        if (previousSurvivors.Count == 0)
        {
            return CreateRandomCharacteristics(
                minSize,
                maxSize
            );
        }

        // Algunas células exploran características nuevas.
        if (Random.value < explorationRate)
        {
            return CreateRandomCharacteristics(
                minSize,
                maxSize
            );
        }

        // Seleccionamos un superviviente de la
        // generación anterior.
        CellExperience parent =
            previousSurvivors[
                Random.Range(0, previousSurvivors.Count)
            ];

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