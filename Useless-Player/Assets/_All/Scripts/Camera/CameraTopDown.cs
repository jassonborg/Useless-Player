using UnityEngine;
using System.Collections;

public class CameraTopDown : MonoBehaviour
{
	public GameObject player;
	private Vector3 offsetPos;

	void Start()
	{
		 // Find the GameObject named Player
		offsetPos = new Vector3(0, 17f, -13f); // Set the camera's offset position
	}

	void OnEnable()
	{
		gameObject.transform.parent = null; // This makes the camera a parent object rather than a child
	}
	
	void LateUpdate()
	{
		if(player != null)
		{
			transform.rotation = Quaternion.Euler(55f, 0, 0); // Set the camera's rotation
			transform.position = player.transform.position + offsetPos; // Set cameras final position
		}
		
	}
}