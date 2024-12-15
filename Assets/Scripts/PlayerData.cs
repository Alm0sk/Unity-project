using System;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public string Pseudo;
    public int Score;
}

[System.Serializable]
public class PlayerDataList
{
    public List<PlayerData> Players = new List<PlayerData>();
}
