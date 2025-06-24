using UnityEngine;

public class EnemyStateChase : State<States>
{
    private GameObject Wolf;
    private EnemyController controller;
    private GameObject sheep;

    public EnemyStateChase(GameObject wolfSteering, EnemyController controller)
    {
       this.Wolf = wolfSteering;
        this.controller = controller;
    }

    public override void OnEnter()
    {
        sheep = controller.Sheep;
        var steering = Wolf.GetComponent<WolfSteering>();
        steering.Sheeptarget = sheep.transform;
        steering.Sheeptargetrb = sheep.GetComponent<Rigidbody>();

        steering.ChangeStearingMode(WolfSteering.SteeringMode.persuit);
    }

    public override void FixedExecute()
    {
        Wolf.GetComponent<WolfSteering>().ExecuteSteering();
    }

    public override void OnExit()
    {
        
    }
}



