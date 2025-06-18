using UnityEngine;

public class WolfEnemy : MonoBehaviour
{

    private int damage = 10;
    public lineofsight lineofsight;
    public EnemyController enemyController;
    bool sawsheep = false;  

    public void attack(Sheep sheep)
    {

        sheep.Life -= damage;
    }
}