using UnityEngine;

public class Sheep : MonoBehaviour
{

    int life = 10;

    public int Life {  get { return life; } set { life = value; } }



    public void Death()
    {
        if (life== 0) Destroy(gameObject);
    }
    

}