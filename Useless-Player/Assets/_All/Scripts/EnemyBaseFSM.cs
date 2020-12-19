using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseFSM : StateMachineBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float speed = 15.0f;
    public float rotSpeed = 10.0f;
    public float accuracy = 3.0f;
    public NavMeshAgent agent;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        enemy = animator.gameObject;
        player = enemy.GetComponent<BossAI>().GetPlayer();
        agent = enemy.GetComponent<NavMeshAgent>();
    }
    


}
