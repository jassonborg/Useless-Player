using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject followEnemy;
    public GameObject[] aiPrefabsToSpawn;
    public float[] spawnTimer;
    public float[] spawnCeiling;
    public float[] spawnFloor;
    public float[] InstantiateHeight;
    public float[] lastSpawnTimer;
    public float playerFollowSpeed = 50;
    float lengthOfRaycast = 9999;
    Vector3 spawnObjectMoveTowardsVector;
    Vector3 raycastOriginPoint;
    bool spawnIsAGo;
    bool spawnNoGo;
    public LayerMask layerMaskRaycast;
    public LayerMask layerMaskNoSpawn;
    public float setDistance;
    public float steepnessBufferAngle;
    private GameObject spawnPlane;
    float timerFunc;

    void Start()
    {

        timerFunc = 0;

        // Initialize the last spawn timer array.
        for (int arrayIndex = 0; arrayIndex < lastSpawnTimer.Length; arrayIndex++)
            lastSpawnTimer[arrayIndex] = Time.time;
    }

	void Update()
	{

		// ========================= FOLLOW THE PLAYER ========================= //
		// Controls the movement of randomGenerationObj, the plane that has this script attached to it. This keeps it above the player at all times.
		// The value 60 below controls the height above the player, and the players X/Z axis determines the spawners X/Z axes.
		spawnObjectMoveTowardsVector = new Vector3(followEnemy.transform.position.x, followEnemy.transform.position.y + 120, followEnemy.transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, spawnObjectMoveTowardsVector, playerFollowSpeed * Time.deltaTime);


		// ========================= MAIN LOOP ========================= //
		// Goes through the array of objects that you set in the Inspector window, and handles each one.
		for (int arrayIndex = 0; arrayIndex < aiPrefabsToSpawn.Length; arrayIndex++)
		{
			// Assign the 'Spawner' a random location within the Spawn-Plane.

			if (timerFunc == 10)
			{ // Reduce the number of times we calculate a random location.
				raycastOriginPoint = getRandomLocation();
				timerFunc = 0;
			}
			else
				timerFunc++;

			// Cast the ray downward from this random location to get information from the impact.
			Vector3 raycastDirection = transform.TransformDirection(Vector3.down);
			// We need the RaycastHit point to get information about where the raycast hit the terrain.
			RaycastHit impactPoint;
			// Check for a no-spawn layer impact.

			// ============================== SPAWN GO/NO-GO ============================== //
			if (Physics.Raycast(raycastOriginPoint, raycastDirection, out impactPoint, lengthOfRaycast, layerMaskNoSpawn))
			{
				spawnNoGo = true;
			}
			else
				spawnNoGo = false;
			// Check for a yes-spawn layer impact. Order of these two is important; this second raycast is the one with important spawn information.
			if (Physics.Raycast(raycastOriginPoint, raycastDirection, out impactPoint, lengthOfRaycast, layerMaskRaycast))
				spawnIsAGo = true;
			else
			{
				spawnIsAGo = false;
			}

			// If the point calculated is above the ceiling, OR below the floor, then wait to spawn until next calculation.
			if ((spawnCeiling[arrayIndex] < impactPoint.point.y) || (spawnFloor[arrayIndex] > impactPoint.point.y))
			{
				spawnIsAGo = false;
			}

			// If the point calculated is within the buffer zone (no spawn near player), then wait to spawn until next calculation.
			if (playerBufferArea(followEnemy.transform.position, impactPoint.point, setDistance) == false)
			{
				spawnIsAGo = false;
			}

			// If the terrain normal angle is less than the buffer set in the inspector, don't spawn there (0.0 to 1.0, steep to flat.)
			if (terrainBufferAngle(impactPoint.normal, steepnessBufferAngle) == false)
			{
				spawnIsAGo = false;
			}

			// ============================== INITIATE SPAWN ============================== //
			// If there is no obstacle/no-spawn area, and we struck terrain, start spawn.
			if (spawnIsAGo & (!spawnNoGo))
			{
				// At this point we are sure we have a good spot to spawn something.
				if ((Time.time - lastSpawnTimer[arrayIndex]) > spawnTimer[arrayIndex])
				{
					// At this point we are sure its time to spawn the next prefab for this element in the array
					Instantiate(aiPrefabsToSpawn[arrayIndex], new Vector3(impactPoint.point.x, impactPoint.point.y + InstantiateHeight[arrayIndex], impactPoint.point.z), Quaternion.identity);
					lastSpawnTimer[arrayIndex] = Time.time; // Reset the clock for the next spawn
				}


			}
		}
	}

	// This function gets a random location in the spawn plane.
	Vector3 getRandomLocation()
	{
		// Generate random coordinates within this plane:
		// The position of the plane is the center point within the plane; this is where the player is!
		// The local scale of the plan is the length of the plane along one side, like the side of a square.
		// spawnBoundary moves the random range away from the center point; since the player is here, this means we created a buffer away from the player for the range.
		float randomX = Random.Range(gameObject.transform.position.x - (gameObject.transform.localScale.x * 4), gameObject.transform.position.x + (gameObject.transform.localScale.x * 4));
		float unchangedY = gameObject.transform.position.y; // No need to change this for the spawner, its a plane so its only 2 Dimensional
		float randomZ = Random.Range(gameObject.transform.position.z - (gameObject.transform.localScale.z * 4), gameObject.transform.position.z + (gameObject.transform.localScale.z * 4));

		// We now create a vector from the three positions so that we can give our raycast an origin point!
		Vector3 randomPosition = new Vector3(randomX, unchangedY, randomZ);

		Vector3 originForDebugRay = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
		Debug.DrawLine(originForDebugRay, randomPosition);

		return randomPosition;
	}

	bool playerBufferArea(Vector3 playerPosition, Vector3 impactPoint, float setDistance)
	{
		// Calculate the distance between the player and the spawn point.
		// If they are too close, return false.

		float distanceToSpawn = Vector3.Distance(playerPosition, impactPoint);

		// If the distance to the spawn point is greater than the distance set in the inspector, return true.
		if (distanceToSpawn > setDistance)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool terrainBufferAngle(Vector3 terrainNormal, float bufferAngle)
	{
		// This function analyzes the normal vector of the terrain to see if it is steep or not.
		if (bufferAngle <= terrainNormal.y)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
