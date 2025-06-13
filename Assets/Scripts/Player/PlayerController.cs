using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed = 10;
    private Rigidbody rb;
 
    void Movement()
    {
        float horiontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (horiontalInput, 0f, verticalInput) * speed;

        rb.MovePosition (rb.position + movement * Time.fixedDeltaTime);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
