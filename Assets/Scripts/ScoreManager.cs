using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Texte UI du score (TextMeshPro)

    void Start()
    {

        // Initialise le score s'il n'est pas d�j� d�fini
        if (DataPersistance.Score < 0)
        {
            DataPersistance.Score = 0;
        }

        // Met � jour le texte affich� � l'�cran
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        DataPersistance.Score += points;
        Debug.Log("Score ajout� : " + points + ", Score total : " + DataPersistance.Score);

        UpdateScoreUI();
    }


    private void UpdateScoreUI()
    {
        // Affiche le score mis � jour dans le texte UI
        scoreText.text = "Score de " + DataPersistance.Pseudo + " : " + DataPersistance.Score.ToString();
    }
}
