using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Texte UI du score (TextMeshPro)

    void Start()
    {

        // Initialise le score s'il n'est pas déjà défini
        if (DataPersistance.Score < 0)
        {
            DataPersistance.Score = 0;
        }

        // Met à jour le texte affiché à l'écran
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        DataPersistance.Score += points;
        Debug.Log("Score ajouté : " + points + ", Score total : " + DataPersistance.Score);

        UpdateScoreUI();
    }


    private void UpdateScoreUI()
    {
        // Affiche le score mis à jour dans le texte UI
        scoreText.text = "Score: " + DataPersistance.Score.ToString();
    }
}
