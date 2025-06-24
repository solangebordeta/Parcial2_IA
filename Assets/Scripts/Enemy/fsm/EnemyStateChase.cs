using UnityEngine;

public class EnemyStateChase : State<States>
{
    private WolfSteering steering;
    private EnemyController controller;
    private GameObject sheep;

    public EnemyStateChase(WolfSteering wolfSteering, EnemyController controller)
    {
        this.controller = controller;
    }

    public override void OnEnter()
    {
        sheep = controller.Sheep;

        steering.Target = sheep;
        steering.ChangeStearingMode(WolfSteering.SteeringMode.persuit);
    }

    public override void FixedExecute()
    {
        steering.ExecuteSteering();
    }

    public override void OnExit()
    {
        controller.Sheep = null;
    }
}



