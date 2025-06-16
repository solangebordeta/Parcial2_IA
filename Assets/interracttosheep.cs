using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interracttosheep : MonoBehaviour
{
    public  LayerMask mask;
    [SerializeField] float Rad;
    [SerializeField] Canvas canvas;

    
   public void Interact()
    {

        

            if (Physics.SphereCast(this.transform.position, Rad, transform.position, out RaycastHit hit, mask))
        {
            canvas.gameObject.SetActive(true);
            Debug.Log("viendo");
        }
            
          
        
            
    }

    private void OnDrawGizmos()
    {
  
    Gizmos.color = Color.red;
       
        Gizmos.DrawSphere(transform.position, Rad);
    }
}
