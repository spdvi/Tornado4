using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<NavMeshAgent>().destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
        }
        
    }
}
