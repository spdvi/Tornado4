using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy1 : MonoBehaviour
{
    public float enemySpeed = 1.0f;
    public int rangoDesplazamiento = 4;
    private float desplazamientoTemporal = 0f;
    private float posicionXInicial;

    private void Start()
    {
        posicionXInicial = transform.position.x;
    }

    void Update()
    {
        //transform.position = transform.position + new Vector3(enemySpeed*Time.deltaTime, 0, 0);
        transform.Translate(enemySpeed * Time.deltaTime, 0, 0);
        if (transform.position.x - posicionXInicial >= rangoDesplazamiento)
        {
            enemySpeed = enemySpeed * -1;
        }
        else if (transform.position.x - posicionXInicial <= 0.1f)
        {
            enemySpeed = enemySpeed * -1;
        }
        
        
    }
}
