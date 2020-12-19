using UnityEngine;


public class CharacterAnimation : MonoBehaviour
{

	// Public boolean for running animation
	public bool _animRun;
	public bool _animPuke;

	// Animator variables
	private Animator anim;
	private string animRun = "Run";
	private string animPuke = "Puke";

	void Start()
	{
		anim = GetComponent<Animator>();    // Get the animator component
	}

	void Update()
	{
		Run();
		Puke();
	}

	void Run()
	{
		if (_animRun)   // If _animRun is true then continue
		{
			anim.SetBool(animRun, true);    // Set the animator Bool with the String Value of animRun to True
		}
		else    // If _animRun is false then continue
		{
			anim.SetBool(animRun, false);   // Set the animator Bool with the String Value of animRun to True
		}
	}

	void Puke()
	{
		if(_animPuke)
		{
			anim.SetBool(animPuke, true);
		}
		else
		{
			anim.SetBool(animPuke, false);
			
		}
	}

	
}

