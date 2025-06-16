using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float detectionRange = 5f; // Radio de detecci�n de obst�culos.
    [SerializeField] private float avoidForce = 10f;     // Fuerza para evitar el obst�culo.
    [SerializeField] private LayerMask obstacleMask;     // Capas consideradas obst�culos.

    public Vector3 Avoid()
    {
        // Detecta todos los colliders dentro del rango
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, obstacleMask);

        if (colliders.Length == 0) return Vector3.zero;

        float minDist = detectionRange + 1;

        Collider closestCol = null;

        // Busca el obst�culo m�s cercano
        foreach (var col in colliders)
        {
            float currentDist = Vector3.Distance(transform.position, col.ClosestPoint(transform.position));

            if (currentDist < minDist)
            {
                minDist = currentDist;
                closestCol = col;
            }
        }

        if (closestCol == null) return Vector3.zero;

        // Calcula direcci�n opuesta al punto m�s cercano del obst�culo
        Vector3 directionAway = transform.position - closestCol.ClosestPoint(transform.position);

        // Ignora la altura (y)
        directionAway.y = 0;

        // Normaliza la direcci�n y aplica la fuerza de evasi�n
        Vector3 avoidDir = directionAway.normalized * avoidForce;

        // Aplica atenuaci�n seg�n qu�Etan cerca est�Edel obst�culo
        float distanceFactor = Mathf.Lerp(1, 0, minDist / detectionRange);

        avoidDir *= distanceFactor;

        return avoidDir;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
