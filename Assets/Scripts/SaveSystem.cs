using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string directoryPath;
    private string filePath;

    void Start()
    {
        // Spécifiez le chemin du répertoire JSON
        directoryPath = Application.persistentDataPath + "/JSON";

        // Spécifiez le chemin complet du fichier JSON
        filePath = directoryPath + "/playerData.json";

        // Vérifie si le répertoire existe, sinon le crée
        if (!Directory.Exists(directoryPath))
        {
            Debug.Log("Fichier Json créé " + filePath);
            Directory.CreateDirectory(directoryPath);
        }

        Debug.Log("Fichier Json : " + filePath);

        // Créer un fichier par défaut si inexistant
        if (!File.Exists(filePath))
        {
            
            CreateDefaultFile();
        }

        // Charger les données après avoir vérifié ou créé le fichier
        LoadData();
    }

    public void SaveData()
    {
        // Charger les données existantes
        PlayerDataList dataList = LoadDataList();

        // Chercher si le joueur existe déjà
        bool playerFound = false;
        foreach (PlayerData player in dataList.Players)
        {
            if (player.Pseudo == DataPersistance.Pseudo)
            {
                playerFound = true;
                if (DataPersistance.Score > player.Score)
                {
                    player.Score = DataPersistance.Score; // Met à jour si meilleur score
                    Debug.Log("Score mis a jour");
                
                }
                break;
            }
        }

        // Si joueur non trouvé, l'ajouter
        if (!playerFound)
        {
            Debug.Log("joueur non trouvé dans la liste");
                
            dataList.Players.Add(new PlayerData
            {
                Pseudo = DataPersistance.Pseudo,
                Score = DataPersistance.Score               
                
            });
            Debug.Log("Données chargées pour : " + DataPersistance.Pseudo + " et score " + DataPersistance.Score);

        }

        // Sauvegarder dans le fichier
        File.WriteAllText(filePath, JsonUtility.ToJson(dataList, true));
    }

    public void LoadData()
    {
        PlayerDataList dataList = LoadDataList();

        // Afficher les données ou les assigner pour utilisation
        foreach (var player in dataList.Players)
        {
            if (player.Pseudo == DataPersistance.Pseudo)
            {
                DataPersistance.Score = player.Score; // Récupère le meilleur score
                Debug.Log($"Données chargées pour {player.Pseudo} : Score = {player.Score}");
                break;
            }
        }
    }

    public PlayerDataList LoadDataList()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<PlayerDataList>(jsonData);
        }
        else
        {
            return new PlayerDataList();
        }
    }

    private void CreateDefaultFile()
    {
        PlayerDataList defaultData = new PlayerDataList();
        File.WriteAllText(filePath, JsonUtility.ToJson(defaultData, true));
    }
}
