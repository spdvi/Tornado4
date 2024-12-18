using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using Tornado4.Player;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPSLevelManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public GameObject youWinCanvas;
    public GameObject youLoseCanvas;
    public PlayerFPSMove playerFPSMove;
    public PlayerFPSLook playerFPSLook;
    public Image healthBarImage;
    public Transform player;
    
    public GameDataSO gameData;
    
    private int coins = 0;
    public float countDownTime  = 3.0f;
    
    public GameObject savingSystem;
    
    private void Start()
    {
        youWinCanvas.SetActive(false);
        youLoseCanvas.SetActive(false);
    }

    private void Update()
    {
        countDownTime -= Time.deltaTime;
        healthBarImage.fillAmount = countDownTime / 3f;
        if (countDownTime <= 0)
        {
            LoseGame();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // SaveLevelData levelData = new SaveLevelData();
            // levelData.NumCoins = coins;
            // levelData.LevelTime = countDownTime;
            // levelData.LevelName = SceneManager.GetActiveScene().name;
            SerializableVector3 position = new SerializableVector3(player.position.x,
                player.position.y, player.position.z);
            
            SaveLevelData levelData = new SaveLevelData(coins,
                SceneManager.GetActiveScene().name,
                countDownTime, position);
            
            JObject levelDataJson = JObject.FromObject(levelData);

            savingSystem.GetComponent<SavingSystem>().SaveFileAsJSon("partida3",
                levelDataJson);
            
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Deserializar json
            JObject levelDataJson = savingSystem.GetComponent<SavingSystem>().LoadJsonFromFile("partida3");
            SaveLevelData levelData = new SaveLevelData();
            levelData.NumCoins = (int)levelDataJson["NumCoins"];
            levelData.LevelTime = (float)levelDataJson["LevelTime"];
            levelData.LevelName = (string)levelDataJson["LevelName"];
            levelData.PlayerPosition = levelDataJson["PlayerPosition"].ToObject<SerializableVector3>();

            // // Restaurar valores guardados
            countDownTime = levelData.LevelTime;
            player.position = levelData.PlayerPosition.ToVector3();
            Debug.Log(levelData.LevelName);
        }
        
    }

    public void CoinCollected()
    {
        coins++;
        coinsText.text = coins.ToString();

        if (coins == 3)
        {
            WinGame();
        }
    }

    public void PlayerOnConsole()
    {
        SceneManager.LoadSceneAsync("New Scene Additive", LoadSceneMode.Additive);
    }

    public void PlayerOutOfConsole()
    {
        SceneManager.UnloadSceneAsync("New Scene Additive");
    }
    
    private void WinGame()
    {
        gameData.collectedCoins = coins;
        
        //Debug.Log("You Win!");
        // Mostrar Canvas You Win
        youWinCanvas.SetActive(true);
            
        // Desactivar moviment del Player
        playerFPSMove.enabled = false;
        playerFPSLook.enabled = false;
            
        // Mostrar el cursor del ratolí
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LoseGame()
    {
        youLoseCanvas.SetActive(true);
        
        // Desactivar moviment del Player
        playerFPSMove.enabled = false;
        playerFPSLook.enabled = false;
            
        // Mostrar el cursor del ratolí
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
