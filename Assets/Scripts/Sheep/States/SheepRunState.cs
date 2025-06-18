public class SheepRunState : State<States>
{
    private SheepSteering controller;

    public SheepRunState(SheepSteering controller)
    {
        this.controller = controller;
    }

    public override void OnEnter()
    {
        controller.ChangeStearingMode(SheepSteering.SteeringMode.flee);
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
