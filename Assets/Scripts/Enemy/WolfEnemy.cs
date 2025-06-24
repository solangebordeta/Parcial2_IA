using UnityEngine;

public class WolfEnemy : MonoBehaviour
{
    private int damage = 10;

    public void attack(Sheep sheep)
    {
        sheep.Life -= damage;
    }
}