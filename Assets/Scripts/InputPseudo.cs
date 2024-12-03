using UnityEngine;
using UnityEngine.UI;

public class InputPseudo : MonoBehaviour
{
    public InputField inputField; // L'InputField où l'utilisateur saisit son pseudo
    public Button submitButton;   // Le bouton qui soumet le pseudo

    // Start is appelé une seule fois au début
    void Start()
    {
        // S'assurer que le bouton est assigné et qu'on peut écouter le clic
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(AfficherPseudo);
        }
    }

    // Fonction pour récupérer et afficher le pseudo
    public void AfficherPseudo()
    {
        if (inputField != null)
        {
            DataPersistance.Pseudo = inputField.text; // Récupère le texte saisi
            Debug.Log("Joueur : " + DataPersistance.Pseudo); // Affiche dans la console
        }
    }
}
