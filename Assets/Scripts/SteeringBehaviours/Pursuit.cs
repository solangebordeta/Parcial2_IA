using UnityEngine;

public class Persuit : ISteering
{
    private Rigidbody rb;
    private GameObject target;
    private float maxVelocity;
    private float timePrediction = 1;

    public Persuit(Rigidbody rb, GameObject Target, float maxVelocity, float timePrediction)
    {
        this.rb = rb;
        this.target = Target;
        this.maxVelocity = maxVelocity;
        this.timePrediction = timePrediction;
    }

    public Vector3 MoveDirection()
    {
        var targetRb = target.GetComponent<Rigidbody>();
        // Predice la futura posición del objetivo según su velocidad.
        Vector3 predicitonPosition = targetRb.position + targetRb.velocity * timePrediction * Vector3.Distance(rb.position, targetRb.position);
        // Apunta hacia esa posición futura.
        Vector3 desiredVelocity = (predicitonPosition - rb.position).normalized * maxVelocity;
        Vector3 directionForce = desiredVelocity - rb.velocity;
        directionForce.y = 0;
        directionForce = Vector3.ClampMagnitude(directionForce, maxVelocity);
        return desiredVelocity;
    }
}
