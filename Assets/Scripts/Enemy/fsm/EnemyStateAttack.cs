using UnityEngine;

public class EnemyStateAttack : State<States>
{
    GameObject Enemy;
    EnemyController Controller;
    GameObject sheepGO;
    Sheep sheep;
    public EnemyStateAttack(GameObject enemy, GameObject Sheep, EnemyController controller)
    {
        Enemy = enemy;
        this.sheepGO = Sheep;
        Controller = controller;
    }

    public override void OnEnter()
    {
        sheepGO = Controller.Sheep; 
        sheep = sheepGO.GetComponent<Sheep>();
        Enemy.GetComponent<WolfEnemy>().attack(sheep);
    }
    public override void Execute()
    {
        
    }
    public override void FixedExecute()
    {
    
    }

    public override void OnExit() 
    {
        var steering = Enemy.GetComponent<WolfSteering>();
        steering.Sheeptarget = null;
        steering.Sheeptargetrb = null;
        Controller.Sheep = null;
    }
}
