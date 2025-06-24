using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class interracttosheep : MonoBehaviour
{
    public  LayerMask mask;
    float distance = 10;
    [SerializeField] LayerMask MASk;

    [SerializeField] Canvas canvas;
    public void Interact()
    {
        Debug.DrawRay(transform.position, transform.forward,Color.cyan);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance, MASk))
        {
            Debug.Log("funca");

            canvas.gameObject.SetActive(true);
            if (hit.collider.CompareTag("Sheep") && Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponentInParent<SheepController>().isFollowingPlayer = true;

            }
        }
     


    
            
          
        
            
    }

}
