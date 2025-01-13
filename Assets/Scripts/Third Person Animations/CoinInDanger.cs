using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInDanger : MonoBehaviour
{
    public GameObject animatedCoin;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animatedCoin.GetComponent<Animator>().SetBool("IsInDanger", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animatedCoin.GetComponent<Animator>().SetBool("IsInDanger", false);
        }
    }
}
