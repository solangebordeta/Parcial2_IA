public class SheepFlockState : State<States>
{
    private SheepSteering controller;
    private Flocking flock;

    public SheepFlockState(SheepSteering controller, Flocking flock)
    {
        this.controller = controller;
        this.flock = flock;
    }

    public override void OnEnter()
    {
        controller.ChangeStearingMode(SheepSteering.SteeringMode.follow);
    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {

    }
    public override void OnExit()
    {

    }
}