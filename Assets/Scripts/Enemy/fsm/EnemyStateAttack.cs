using UnityEngine;

public class EnemyStateAttack : State<States>
{
    WolfEnemy Enemy;
    EnemyController Controller;
    GameObject sheepGO;
    Sheep sheep;
    public EnemyStateAttack(WolfEnemy enemy, GameObject Sheep, EnemyController controller)
    {
        Enemy = enemy;
        this.sheepGO = Sheep;
        Controller = controller;
    }

    public override void OnEnter()
    {
        sheepGO = Controller.Sheep; 
        sheep = sheepGO.GetComponent<Sheep>();
    }
    public override void Execute()
    {
        Enemy.attack(sheep);
    }
    public override void FixedExecute()
    {
    
    }

    public override void OnExit() 
    { 
        sheep = null;
        sheepGO = null;
    }
}
