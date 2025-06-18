using NUnit.Framework.Constraints;
using UnityEngine;
using static WolfSteering;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody))]
public class WolfSteering : MonoBehaviour
{
    [Header("Parameters")]
    public float maxVelocity = 10f;
    public float timePrediction = 1f;
    public SteeringMode mode;

    [Header("References")]
    public Transform Playertarget;
    public Rigidbody PlayerRb;
    public Transform Sheeptarget;
    public Rigidbody Sheeptargetrb;
    public ObstacleAvoidance obstacleAvoidance; //(Se arrastra el script desde el inspector)
    private ISteering currentSteering;
    public Rigidbody rb;
    private Vector3 finalForce;

    //instancias de los comportamientos
    Flee flee;
    Persuit persuit;
    Evade evade;
    None none;
    public enum SteeringMode
    {
        flee,
        persuit,
        evade,
        None,
    }

    void Start()
    {
        //se crean los objetos de cada comportameinto con sus dependencias
        none = new(rb);
        flee = new(rb, Playertarget, maxVelocity);
        persuit = new(rb, Sheeptargetrb, maxVelocity, timePrediction);
        evade = new(rb, PlayerRb, maxVelocity, timePrediction);
;
      
        //el comp. inicial es ninguna
        currentSteering = none;
    }
 
    public void ExecuteSteering() //ejecuta la logica del comportamiento
    {
    
        Vector3 steeringDir = currentSteering.MoveDirection();                                                                                                                                       

        //dirección de evasión de obstáculos
        Vector3 avoidDir = obstacleAvoidance ? obstacleAvoidance.Avoid() : Vector3.zero;

        //suma de ambas fuerzas
        finalForce = steeringDir + avoidDir;

        if (steeringDir != Vector3.zero)
        {
            //aplicación de la fuerza al Rigidbody
            rb.AddForce(finalForce, ForceMode.Acceleration);

            //rotación hacia la dirección de movimiento
            if (rb.velocity != Vector3.zero)
                transform.forward = rb.velocity.normalized;
        }

      
    }

    public void ChangeStearingMode(SteeringMode mode) //cambia el comportamiento segun el modo
    {
        this.mode = mode;

        switch (mode)
        {
        
            case SteeringMode.flee:
                currentSteering = flee;
                break;
            case SteeringMode.persuit:
                currentSteering = persuit;
                break;
            case SteeringMode.evade:
                currentSteering = evade;
                break;
                case SteeringMode.None: currentSteering = none; 
                break;

        }
    }
}

