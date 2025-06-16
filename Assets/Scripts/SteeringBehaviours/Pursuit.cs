using UnityEngine;

public class Persuit : ISteering
{
    private Rigidbody rb;
    private Rigidbody targetRb;
    private float maxVelocity;
    private float timePrediction = 1;

    public Persuit(Rigidbody rb, Rigidbody target, float maxVelocity, float timePrediction)
    {
        this.rb = rb;
        this.targetRb = target;
        this.maxVelocity = maxVelocity;
        this.timePrediction = timePrediction;
    }

    public Vector3 MoveDirection()
    {
        // Predice la futura posici�n del objetivo seg�n su velocidad.
        Vector3 predicitonPosition = targetRb.position + targetRb.velocity * timePrediction * Vector3.Distance(rb.position, targetRb.position);
        // Apunta hacia esa posici�n futura.
        Vector3 desiredVelocity = (predicitonPosition - rb.position).normalized * maxVelocity;
        Vector3 directionForce = desiredVelocity - rb.velocity;
        directionForce.y = 0;
        directionForce = Vector3.ClampMagnitude(directionForce, maxVelocity);
        return desiredVelocity;
    }
}
