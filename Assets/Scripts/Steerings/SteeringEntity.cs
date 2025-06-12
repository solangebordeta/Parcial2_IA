using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SteeringEntity : MonoBehaviour
{
    public Rigidbody target;
    public float maxVelocity;
    public float timePrediction;
    public SteeringMode mode;
    private ISteering currentSteering;
    private Rigidbody rb;

    Vector3 desiredVelocity;
    public enum SteeringMode
    {
        seek,
        flee,
        persuit,
        evade
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Seek seek = new(rb, target.transform, maxVelocity);
        Flee flee = new(rb, target.transform, maxVelocity);
        Persuit persuit = new(rb, target, maxVelocity, timePrediction);
        Evade evade = new(rb, target, maxVelocity, timePrediction);

        switch (mode)
        {
            case SteeringMode.seek:
                currentSteering = seek;
                break;
            case SteeringMode.flee:
                currentSteering = flee;
                break;
            case SteeringMode.persuit:
                currentSteering = persuit;
                break;
            case SteeringMode.evade:
                currentSteering = evade;
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        desiredVelocity = currentSteering.MoveDirection();
        transform.forward = rb.velocity;
    }

    private void OnDrawGizmos()
    {
        if (!rb || !target) return;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(rb.position, rb.position + rb.velocity * 3);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position + desiredVelocity);

        Gizmos.DrawWireSphere(target.position + target.velocity * timePrediction * Vector3.Distance(rb.position, target.position), 2);
    }
}
