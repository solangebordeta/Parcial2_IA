using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyLOS : MonoBehaviour
{
    [SerializeField] private LayerMask obstaclesMask;

    public float detectionRange;
    public float loseplayer;
    public float detectionAngle;

    public EnemyController controller;

    //Comprueba si el objetivo estÅEdentro del rango de visiÛn.


    public bool seeingsomething()
    {

        Collider[] hit = Physics.OverlapSphere(transform.position, detectionRange, obstaclesMask);
    
        for (int i = 0; i < hit.Length; i++)
            {
     
            if (Physics.Raycast(transform.position, hit[i].transform.position - transform.position, detectionRange,obstaclesMask))
            {
              if ( hit[i].CompareTag("Sheep") && controller.Sheep == null)

                {
                    controller.Sheep = hit[i].transform.parent.gameObject;

                    return true;
                }
       
            }
            else
            {
                return false;
            }

        }
        return false;
    }
    public bool CheckDistance(Transform target) 
    {
        float distance = Vector3.Distance(target.position, transform.position);

        return distance <= detectionRange;
    }

    //Comprueba si el objetivo estÅEfuera del rango de seguimiento (como para dejar de perseguirlo).
    public bool LosePlayer(Transform target)
    {
        float distance = Vector3.Distance(target.position, this.transform.position);

        return distance > loseplayer;
    }

    // Comprueba si el objetivo estÅEdentro del ·ngulo de visiÛn.
    public bool CheckAngle(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        float angle = Vector3.Angle(transform.forward, dir);
        return angle <= detectionAngle / 2;
    }

    // Comprueba que no haya obst·culos que bloqueen la vista del objetivo.
    public bool CheckView(Transform target)
    {
        Vector3 dir = target.position - transform.position;

        return !Physics.Raycast(transform.position, dir.normalized, dir.magnitude, obstaclesMask);
    }

    private void OnDrawGizmos()
    {
        // Dibuja una esfera que representa el rango de detecciÛn.
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        
        // Dibuja l˙ãeas que representan el ·ngulo de visiÛn.
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, detectionAngle / 2, 0) * transform.forward * detectionRange);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -detectionAngle / 2, 0) * transform.forward * detectionRange);
    }
}



