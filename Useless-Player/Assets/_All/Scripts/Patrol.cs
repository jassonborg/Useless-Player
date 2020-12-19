using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Patrol : EnemyBaseFSM
{
    
    //public List<Transform> wayPoints = new List<Transform>();
    GameObject[] wayPoints;
    int randomWP;
    private void Awake()
    {
        //GetSpawnPoints();
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoints");
    }
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        randomWP = Random.Range(0, (wayPoints.Length));
    }

    ///OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(wayPoints[randomWP].transform.position, enemy.transform.position) >= accuracy)
        {
            var direction = wayPoints[randomWP].transform.position - enemy.transform.position;
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            enemy.transform.Translate(0, 0, Time.deltaTime * speed);
        }
        if (Vector3.Distance(wayPoints[randomWP].transform.position, enemy.transform.position) <= accuracy)
        {
            randomWP = Random.Range(0, wayPoints.Length);
        }

        agent.SetDestination(wayPoints[randomWP].transform.position);
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void Code()
    {
      //if (Vector3.Distance(wayPoints[randomWP].transform.position, enemy.transform.position) >= accuracy)
        //{
        //    var direction = wayPoints[randomWP].transform.position - enemy.transform.position;
        //    enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        //    enemy.transform.Translate(0, 0, Time.deltaTime * speed);
        //}
        //if (Vector3.Distance(wayPoints[randomWP].transform.position, enemy.transform.position) <= accuracy)
        //{
        //    randomWP = Random.Range(0, wayPoints.Length);
        //}

        //// Checking for any Obstacle in front.
        //// Two rays left and right to the object to detect the obstacle.
        //Transform leftRay = enemy.transform;
        //Transform rightRay = enemy.transform;

        ////Use Phyics.RayCast to detect the obstacle
        //if (Physics.Raycast(leftRay.position + (enemy.transform.right * 3), enemy.transform.forward, out hit, avoidDistance, obstacleLayer) 
        //    || Physics.Raycast(rightRay.position - (enemy.transform.right * 3), enemy.transform.forward, out hit, avoidDistance, obstacleLayer))
        //{
        //    //if (hit.collider.gameObject.CompareTag("Obstacles"))
        //    //{
        //        isThereObstacle = true;
        //        enemy.transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        //    //}
        //}

        //// Now Two More RayCast At The End of Object to detect that object has already pass the obsatacle.
        //// Just making this boolean variable false it means there is nothing in front of object.
        //if (Physics.Raycast(enemy.transform.position - (enemy.transform.forward * 3), enemy.transform.right, out hit, avoidDistance, obstacleLayer) ||
        // Physics.Raycast(enemy.transform.position - (enemy.transform.forward * 3), -enemy.transform.right, out hit, avoidDistance, obstacleLayer))
        //{
        //    //if (hit.collider.gameObject.CompareTag("Obstacles"))
        //    //{
        //        isThereObstacle = false;

        //    //}
        //}
        //// Use to debug the Physics.RayCast.
        //Debug.DrawRay(enemy.transform.position + (enemy.transform.right * avoidDistance), enemy.transform.forward * avoidDistance, Color.red);
        //Debug.DrawRay(enemy.transform.position - (enemy.transform.right * avoidDistance), enemy.transform.forward * avoidDistance, Color.red);
        //Debug.DrawRay(enemy.transform.position - (enemy.transform.forward * avoidDistance), -enemy.transform.right * avoidDistance, Color.yellow);
        //Debug.DrawRay(enemy.transform.position - (enemy.transform.forward * avoidDistance), enemy.transform.right * avoidDistance, Color.yellow);

        ////Look At Somthly Towards the Target if there is nothing in front.
        //if (!isThereObstacle)
        //{
        //    Vector3 relativePos = wayPoints[randomWP].transform.position - enemy.transform.position;
        //    Quaternion rotation = Quaternion.LookRotation(relativePos);
        //    enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, rotation, Time.deltaTime);
        //}

        //// Enemy translate in forward direction.
        //enemy.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //enemy. = Vector3.MoveTowards(enemy.transform.position, wayPoints[randomWP].transform.position, speed * Time.deltaTime);
        //
        //if (wayPoints.Length == 0) return;

        //{
        //    currentWP++;


        //    if (currentWP >= wayPoints.Length)
        //    {
        //        currentWP = Random.Range(0, (wayPoints.Length));
        //    }
        //}
        //var direction = wayPoints[currentWP].transform.position - enemy.transform.position;
        //enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        //enemy.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
