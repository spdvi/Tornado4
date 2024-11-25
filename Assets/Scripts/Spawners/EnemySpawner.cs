using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meteoritPrefab;
    public Transform player;
    public float forceMagnitude = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteorit", 0f, 1f);
    }

    private void SpawnMeteorit()
    {
        GameObject nouMeteorit = Instantiate(meteoritPrefab, transform.position, Quaternion.identity);
        Vector3 forceDirection = player.position - transform.position;
        nouMeteorit.transform.rotation = Quaternion.LookRotation(forceDirection);
        nouMeteorit.GetComponent<Rigidbody>().AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
    }
    
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     GameObject nouMeteorit = Instantiate(meteoritPrefab, transform.position, Quaternion.identity);
        //     Vector3 forceDirection = player.position - transform.position;
        //     nouMeteorit.transform.rotation = Quaternion.LookRotation(forceDirection);
        //     nouMeteorit.GetComponent<Rigidbody>().AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        // }
        
    }
    
}
