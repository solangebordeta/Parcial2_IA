using UnityEngine;

public class EnemyStateAttack : State<States>
{
    public WolfEnemy Enemy;


    public EnemyStateAttack(WolfEnemy enemy)
    {
        Enemy = enemy;
    }

    public override void OnEnter()
    {
    
    }
    public override void Execute()
    {

    }
    public override void FixedExecute()
    {
    
    }

    public override void OnExit() { }
}
