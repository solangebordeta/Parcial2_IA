using UnityEngine;

public class Flee : ISteering
{
    private Rigidbody rb;

    private Transform targetTrans;

    private GameObject Target;

    private float maxVelocity;

    public Flee(GameObject Target, float maxVelocity)
    {
        this.Target = Target;   
        this.maxVelocity = maxVelocity;
    }
    public Vector3 MoveDirection()
    {
    targetTrans = Target.transform;
    rb = Target.GetComponent<Rigidbody>();
        // Se aleja del objetivo en vez de acercarse.
        Vector3 desiredVelocity = (rb.position - targetTrans.position).normalized * maxVelocity;
        Vector3 directionForce = desiredVelocity - rb.velocity;

        directionForce.y = 0;
        directionForce = Vector3.ClampMagnitude(directionForce, maxVelocity);

        rb.AddForce(directionForce, ForceMode.Acceleration);
        return directionForce;
    }
}

