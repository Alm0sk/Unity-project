using UnityEngine;
using UnityEngine.SceneManagement;
public class GestionScenes : MonoBehaviour
{
    int numberScene = DataPersistance.numberScenes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  

    private void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene()
    {
        Debug.Log("Scenes/Scene"+numberScene);        
        SceneManager.LoadScene("Scenes/Scene"+numberScene);
        numberScene++;
        DataPersistance.numberScenes=numberScene;
        Debug.Log(DataPersistance.numberScenes);
        
    }
}