using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameDataSO gameData;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Número de monedas en nivel anterior: " + gameData.collectedCoins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
