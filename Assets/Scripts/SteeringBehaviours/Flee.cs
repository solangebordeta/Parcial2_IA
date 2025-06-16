using UnityEngine;

public class Flee : ISteering
{
    private Rigidbody rb;

    private Transform target;

    private float maxVelocity;

    public Flee(Rigidbody rb, Transform target, float maxVelocity)
    {
        this.rb = rb;
        this.target = target;
        this.maxVelocity = maxVelocity;
    }
    public Vector3 MoveDirection()
    {
        // Se aleja del objetivo en vez de acercarse.
        Vector3 desiredVelocity = (rb.position - target.position).normalized * maxVelocity;
        Vector3 directionForce = desiredVelocity - rb.velocity;

        directionForce.y = 0;
        directionForce = Vector3.ClampMagnitude(directionForce, maxVelocity);

        rb.AddForce(directionForce, ForceMode.Acceleration);
        return directionForce;
    }
}

