using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class interracttosheep : MonoBehaviour
{
    public  LayerMask mask;
    float distance = 10;

    [SerializeField] Canvas canvas;
    public void Interact()
    {
      
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance, mask))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.cyan);
            Debug.Log("funca");

            canvas.gameObject.SetActive(true);
            if (hit.collider.CompareTag("Sheep") && Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponentInParent<SheepController>().isFollowingPlayer = true;

            }
        }
     


    
            
          
        
            
    }

}
