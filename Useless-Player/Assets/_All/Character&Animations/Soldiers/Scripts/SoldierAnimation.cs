using UnityEngine;

public class SoldierAnimation : MonoBehaviour
{
	Transform enemy;

	// Animator variables
	private Animator anim;
	
	private string distance = "distance";

	void Start()
	{
		anim = GetComponent<Animator>();    // Get the animator component
		enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
	}

	void Update()
	{
		Distance();
	}

	public void Distance()
    {
		anim.SetFloat(distance, Vector3.Distance(transform.position, enemy.transform.position));
	}

}

