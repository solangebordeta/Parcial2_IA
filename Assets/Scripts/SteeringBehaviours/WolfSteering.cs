using NUnit.Framework.Constraints;
using UnityEngine;
using static WolfSteering;
using static UnityEngine.GraphicsBuffer;
using static Cinemachine.CinemachineTargetGroup;

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
    public GameObject Target;
    public ObstacleAvoidance obstacleAvoidance; //(Se arrastra el script desde el inspector)
    private ISteering currentSteering;
    public Rigidbody rb;
    private Vector3 finalForce;

    //instancias de los comportamientos
    Flee flee;
    Persuit persuit;
    Evade evade;
    None none;
    Seek seek;
    public enum SteeringMode
    {
        flee,
        persuit,
        evade,
        None,
        Move,
    }

 private void Start()
    {
        //se crean los objetos de cada comportameinto con sus dependencias
        none = new(rb);
        flee = new(Target, maxVelocity);
        persuit = new(rb, Target, maxVelocity, timePrediction);
        evade = new(rb, PlayerRb, maxVelocity, timePrediction);
;       seek = new(this.rb, null, 10);
      
        //el comp. inicial es ninguna
        currentSteering = none;
    }
 
    public void ExecuteSteering() //ejecuta la logica del comportamiento
    {

        Vector3 steeringDir = currentSteering.MoveDirection();                                                                                                                                       

        //direccion de evasión de obstaculos
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

    public void changeDirection(Transform newtarget)
    {
        seek.target = newtarget;
    }

    public void ChangeStearingMode(SteeringMode mode) //cambia el comportamiento segun el modo
    {
        this.mode = mode;

        switch (mode)
        {
            case SteeringMode.flee:
                flee = new(Target, maxVelocity);
                currentSteering = flee;
                break;
            case SteeringMode.persuit:
                persuit = new(rb, Target, maxVelocity, timePrediction);
                currentSteering = persuit;
                break;
            case SteeringMode.evade:
                currentSteering = evade;
                break;
                case SteeringMode.None: currentSteering = none; 
                break;
            case SteeringMode.Move:
                currentSteering = seek; break;

        }
    }
}

