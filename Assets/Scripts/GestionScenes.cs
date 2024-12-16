using UnityEngine;
using UnityEngine.SceneManagement;
public class GestionScenes : MonoBehaviour
{
    //int numberScene = DataPersistance.numberScenes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int scene = 1;

    private void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSceneBoutonJouer()
    {
        //Debug.Log("Scene 1");        
        SceneManager.LoadScene("Level_01"); // TODO: rediriger vers la scène de départ
        /*numberScene++;
        DataPersistance.numberScenes=numberScene;
        Debug.Log(DataPersistance.numberScenes);
        */
    }

    public void LoadSceneBoutonRejouer()
    {
        //Debug.Log("Scene 1"); 
        DataPersistance.Score=0;       
        SceneManager.LoadScene(0); // TODO: rediriger vers la scène de départ
        /*numberScene++;
        DataPersistance.numberScenes=numberScene;
        Debug.Log(DataPersistance.numberScenes);
        */
    }

}