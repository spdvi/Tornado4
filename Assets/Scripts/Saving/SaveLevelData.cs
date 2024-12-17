[System.Serializable]
public class SaveLevelData
{
    public int NumCoins { get; set; }
    public string LevelName { get; set; }
    public float LevelTime { get; set; }

    public SerializableVector3 PlayerPosition { get; set; }
    public SaveLevelData()
    {
        NumCoins = 3;
        LevelName = "Sin inicializar";
        LevelTime = 50f;
        PlayerPosition = new SerializableVector3();
    }
    
    public SaveLevelData(int numCoins, string levelName, float levelTime, SerializableVector3 playerPosition)
    {
        NumCoins = numCoins;
        LevelName = levelName;
        LevelTime = levelTime;
        PlayerPosition = playerPosition;
    }
}

