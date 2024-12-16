[System.Serializable]
public class SaveLevelData
{
    public int NumCoins { get; set; }
    public string LevelName { get; set; }
    public float LevelTime { get; set; }

    public SaveLevelData()
    {
        NumCoins = 3;
        LevelName = "Sin inicializar";
        LevelTime = 50f;
    }
    
    public SaveLevelData(int numCoins, string levelName, float levelTime)
    {
        NumCoins = numCoins;
        LevelName = levelName;
        LevelTime = levelTime;
    }
}

