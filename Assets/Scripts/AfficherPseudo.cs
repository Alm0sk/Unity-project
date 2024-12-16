using UnityEngine;
using UnityEngine.UI;

public class AfficherPseudo : MonoBehaviour
{
    public Text pseudoText;  // Référence au Text où afficher le pseudo

    // Start est appelé une seule fois au début
    void Start()
    {
        // Vérifie si le Text a bien été assigné
        if (pseudoText != null)
        {
            // Récupère le pseudo depuis DataPersistance et l'affiche dans le Text
            pseudoText.text = "Score de " + DataPersistance.Pseudo + " : " + DataPersistance.Score +  " !";
        }
        else
        {
            Debug.LogError("Le Text n'est pas assigné dans l'Inspector.");
        }
    }
}
