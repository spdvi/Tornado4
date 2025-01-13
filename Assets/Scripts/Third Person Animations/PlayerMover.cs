using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5.662f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        GetComponent<CharacterController>().Move(movement*moveSpeed*Time.deltaTime);
        
        Vector3 velocity = GetComponent<CharacterController>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
