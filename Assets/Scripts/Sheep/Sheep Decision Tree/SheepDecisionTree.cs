using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class SheepDecisionTree : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform enemy;
    [SerializeField] SheepController SheepController;
    [SerializeField] SheepSteering SheepSteering;
    SheepRunState run;
    SheepMoveState move;
    SheepFlockState flock;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DoTree()
    {
        if (Vector3.Distance(enemy.position, transform.position) < 5) //si el enemigo esta cerca
        {
            //SheepRunState.run;
            Debug.Log("estoy corriendo");
        }
        else
        {
            if (Vector3.Distance(player.position, transform.position) < 5)
            {
                Debug.Log("voy al jugador");
            }
            else
            {
                Debug.Log("me quedo en mi lugar");
            }
        }

    }
}
