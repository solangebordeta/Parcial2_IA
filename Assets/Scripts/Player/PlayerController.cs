using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed = 10;

  public void Movement( Rigidbody rigidbody)
    {
        Rigidbody rb = rigidbody;
        float horiontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3 (horiontalInput, 0f, verticalInput) * speed;
        rb.MovePosition (rb.position + movement * Time.fixedDeltaTime);
        rb.MoveRotation (Quaternion.LookRotation(movement));
    }


  
 

    
}
