using UnityEngine;

public class EnemyStateAttack : State<States>
{
    WolfEnemy Enemy;
    GameObject sheepGO;
    Sheep sheep;
    public EnemyStateAttack(WolfEnemy enemy, GameObject Sheep)
    {
        Enemy = enemy;
        this.sheepGO = Sheep;
    }

    public override void OnEnter()
    {
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
