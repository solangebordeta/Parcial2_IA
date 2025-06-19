using UnityEngine;

public class Flock : ISteering
{

    private Rigidbody rb;
    private Transform target;
    private Rigidbody targetRb;

    private float maxVelocity;
    public Flock( Transform player, Rigidbody SheepRB,Rigidbody PlayerRb,float velocity ) 
    {
        target = player;
        rb = SheepRB;
        targetRb = PlayerRb;
        maxVelocity = velocity;
    }
    //protected Vector3 Seek(Vector3 target)
    //{
    //    Vector3 desired = (target - this.transform.position).normalized * maxVelocity;
    //    return CalculateSteering(desired);
    //}
    //protected Vector3 CalculateSteering(Vector3 desired)
    //{
    //    Vector3 steering = desired - _velocity;
    //    return Vector3.ClampMagnitude(steering, _maxForce * Time.deltaTime);
    //}
    //protected void AddForce(Vector3 force) => _velocity = Vector3.ClampMagnitude(_velocity + force, maxVelocity);

    //protected void Move()
    //{
     
    //}

    //public Vector3 MoveDirection()
    //{
    //    if (_velocity == Vector3.zero) return;
    //    transform.forward = _velocity;
    //    return transform.position += _velocity * Time.deltaTime;
    //}
}