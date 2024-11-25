using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // Si colisiona con algo y hay que destruirlo pero dejándolo en la escena un intervalo de tiempo
        // para SFX, Particle effects, etc., asegurarse de desactivar componentes 
        // que puedan causar problemas como Collider, Rigidbody, etc.
        if (other.gameObject.tag == "Player")
        {
            // Damage player
            // Play Sound
            // Play Particle Effects
            // ...
            Destroy(gameObject, 0.5f);
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
