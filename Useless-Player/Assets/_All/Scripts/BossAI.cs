using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossAI : MonoBehaviour
{
    EnemyAnimation anim;
    Animator distance;

    public GameObject player;
    public GameObject GetPlayer()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }

    //Attack variables
    public float distanceToAttack;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask attackLayers;

    void Start()
    {
        anim = GetComponent<EnemyAnimation>();
        distance = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        if (player != null)
        {
            distance.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
        }

        Collider[] hitObstacles = Physics.OverlapSphere(transform.position + Vector3.up, distanceToAttack, attackLayers);
        Collider[] attackSphere = Physics.OverlapSphere(attackPoint.position, attackRange, attackLayers);

        if (hitObstacles.Length == 0)
        {
            anim._animChase = true;
            anim._animAttack = false;
        }

        foreach (Collider obstacle in hitObstacles)
        {
            if (Vector3.Distance(obstacle.transform.position, transform.position) <= distanceToAttack)
            {
                transform.LookAt(obstacle.transform);
                //anim._animAttack = true;
                //anim._animChase = false;

                foreach (Collider doDamage in attackSphere)
                    if (obstacle != null)
                    {
                        doDamage.GetComponent<ObstacleHealth>().TakeDamage(1);
                        //anim._animAttack = true;
                        //anim._animChase = false;
                        Debug.Log("Hit " + obstacle.name);
                    }
                    else
                    {
                        anim._animChase = true;
                        anim._animAttack = false;
                    }
            }
            else
            {
                anim._animChase = true;
                anim._animAttack = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
