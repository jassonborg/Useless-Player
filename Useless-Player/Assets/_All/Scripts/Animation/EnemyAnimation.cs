using UnityEngine;


public class EnemyAnimation : MonoBehaviour
{

	// Public boolean for running animation
	public bool _animChase;
	public bool _animAttack;

	// Animator variables
	private Animator anim;
	private string animChase = "Chase";
	private string animAttack = "Attack";

	void Start()
	{
		anim = GetComponent<Animator>();    // Get the animator component
		
	}

	void Update()
	{
		Chase();
		Attack();
	}

	void Chase()
	{
		if (_animChase)   // If _animRun is true then continue
		{
			anim.SetBool(animChase, true);    // Set the animator Bool with the String Value of animRun to True
		}
		else    // If _animRun is false then continue
		{
			anim.SetBool(animChase, false);   // Set the animator Bool with the String Value of animRun to True
		}
	}

	void Attack()
	{
		if (_animAttack)   // If _animRun is true then continue
		{
			anim.SetBool(animAttack, true);    // Set the animator Bool with the String Value of animRun to True
		}
		else    // If _animRun is false then continue
		{
			anim.SetBool(animAttack, false);   // Set the animator Bool with the String Value of animRun to True
		}
	}



}


