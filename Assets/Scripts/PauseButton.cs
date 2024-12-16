using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Text buttonText; // Référence au texte du bouton
    private bool isPaused = false; // État initial (le jeu est actif)

    void Start()
    {
        // Assurez-vous que le bouton affiche le bon texte au démarrage
        UpdateButtonText();
    }

    // Appelé lorsqu'on clique sur le bouton
    public void TogglePause()
    {
        isPaused = !isPaused; // Bascule l'état de pause
        if (isPaused)
        {
            Time.timeScale = 0; // Met le jeu en pause
        }
        else
        {
            Time.timeScale = 1; // Relance le jeu
        }
        UpdateButtonText(); // Met à jour le texte du bouton
    }

    // Met à jour le texte du bouton en fonction de l'état actuel
    private void UpdateButtonText()
    {
        if (isPaused)
        {
            buttonText.text = "Play"; // Affiche "Play" en mode pause
        }
        else
        {
            buttonText.text = "||"; // Affiche "Pause" en mode actif
        }
    }
}
