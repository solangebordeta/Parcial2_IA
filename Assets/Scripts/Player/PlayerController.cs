using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed = 10;
    [SerializeField] Rigidbody rb;
    Vector3 movement;
  public void Movement()
    {
      
        movement.x = Input.GetAxis("Horizontal");
      movement.z = Input.GetAxis("Vertical");
        rb.MovePosition (rb.position + movement * movespeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.identity;
    }


  
 

    
}
