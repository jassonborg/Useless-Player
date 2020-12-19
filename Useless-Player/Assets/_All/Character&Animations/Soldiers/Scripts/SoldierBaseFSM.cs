using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBaseFSM : StateMachineBehaviour
{
    public Transform enemy;
    
    public GameObject soldier;
    public float speed = -200f;
    public float stoppingDistance = 10.0f;
    public float retreatDistance = 5.0f;
    public float rotSpeed = 2.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        soldier = animator.gameObject;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }



}
