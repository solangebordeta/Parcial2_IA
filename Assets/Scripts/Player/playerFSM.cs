using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFSM : MonoBehaviour
{
   public FSM<States> FSM;
    private Rigidbody rb;
   private IdleState idle;
    private MoveState move;
    private PlayerController playerController;
    private Animator playeranim;
    private interracttosheep sheepinteract;
    // Start is called before the first frame update
    void Start()
    {
        sheepinteract = GetComponent<interracttosheep>();
        playerController = GetComponent<PlayerController>();
        playeranim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        idle = new IdleState(playeranim);
        move = new MoveState(rb,playerController,playeranim);


        idle.AddTransition(States.Walk, move);
        move.AddTransition(States.Idle, idle);
        FSM = new FSM<States>(idle);

    }

    // Update is called once per frame
    void Update()
    {
        // Transiciones automáticas según input
        if (IsMoving())
        {
            FSM.OnTransition(States.Walk);
            playeranim.SetBool("IsWalking", true);
            playeranim.SetBool("IsIdle", false);

        }
        else
        {
            FSM.OnTransition(States.Idle);
            playeranim.SetBool("IsWalking", false);
            playeranim.SetBool("IsIdle", true);

        }
        FSM.OnExecute();
        sheepinteract.Interact();
       
    }

    private void FixedUpdate()
    {
        FSM.OnFixedExecute();
    }
    private bool IsMoving()
    {
        return Input.GetKey(KeyCode.UpArrow) ||
               Input.GetKey(KeyCode.DownArrow) ||
               Input.GetKey(KeyCode.LeftArrow) ||
               Input.GetKey(KeyCode.RightArrow);
    }
}
