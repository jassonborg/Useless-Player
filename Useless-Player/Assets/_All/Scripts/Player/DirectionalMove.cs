using UnityEngine;
using UnityEngine.UI;

public class DirectionalMove : MonoBehaviour 
{

	// Animation script
	private CharacterAnimation anim;

	//Stamina bar
	private StaminaBar stamina;

	// Speed variables
	private float speed = 2.5f;
	private float speedHalved = 2.5f;
	private float speedOrigin = 5f;

	//Interactables
	[SerializeField] private float range;
	private IInteractable currentTarget;

	

	void Start()
	{
		anim = GetComponent<CharacterAnimation>(); // Get the animation script
		stamina = GetComponent<StaminaBar>();
	}

 //   private void Update()
 //   {
	//	RaycastForInteractable();

	//	if(currentTarget != null)
 //       {
	//		currentTarget.OnInteract();
 //       }
        
	//}

    void FixedUpdate () 
	{
		
		float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
		float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input

		if (stamina.currentStamina > 0) //if stamina is greater than 0 = player can move
		{
			PlayerMove(horizontal, vertical); // Call the move player function sending horizontal and vertical movements
		}
		if (stamina.currentStamina == 0) //if stamina is equal to 0 = activate Puke animation
		{
			anim._animPuke = true;
		}
		else
		{
			anim._animPuke = false;
		}
	}
	
	private void PlayerMove(float h, float v)
	{
		
		if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
		{
			//Use StaminaBar script instance and control how much Stamina used
			StaminaBar.instance.UseStamina(1);
		
			if (h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
			{
				speed = speedHalved; // Modify the speed to adjust for moving on an angle
			}
			else // If only horizontal OR vertical are pressed individually then continue
			{
				speed = speedOrigin; // Keep speed to it's original value
			}

			Vector3 targetDirection = new Vector3(h, 0f, v); // Set a direction using Vector3 based on horizontal and vertical input
			GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + targetDirection * speed * Time.deltaTime); // Move the players position based on current location while adding the new targetDirection times speed
			RotatePlayer(targetDirection); // Call the rotate player function sending the targetDirection variable
			anim._animRun = true; // Enable the run animation
		}
		else 	// If horizontal or vertical are not pressed then continue
		{
			anim._animRun = false; // Disable the run animation
		}
	}
	
	private void RotatePlayer(Vector3 dir)
	{
		GetComponent<Rigidbody>().MoveRotation(Quaternion.LookRotation(dir)); // Rotate the player to look at the new targetDirection
	}

	



	//Interactables
	//private void RaycastForInteractable()
	//   {
	//	RaycastHit Hit;
	//	Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
	//	Debug.DrawRay(ray.origin, ray.direction, Color.cyan);

	//	//If raycast is hitting something and within range
	//	if(Physics.Raycast(ray, out Hit, range))
	//       {
	//		IInteractable interactable = Hit.collider.GetComponent<IInteractable>();
	//		if(interactable != null)
	//           {
	//			if(Hit.distance <= interactable.MaxRange)
	//               {
	//				if(interactable == currentTarget)
	//                   {
	//					return;
	//                   }
	//                   else if(currentTarget != null)
	//                   {
	//					currentTarget.OnEndHover();
	//					currentTarget = interactable;
	//					currentTarget.OnStartHover();
	//					return;
	//                   }
	//				else
	//                   {
	//					currentTarget = interactable;
	//					currentTarget.OnStartHover();
	//					return;
	//				}
	//               }
	//			else
	//               {
	//				if(currentTarget != null)
	//                   {
	//					currentTarget.OnEndHover();
	//					currentTarget = null;
	//					return;
	//                   }
	//               }
	//           }
	//		else
	//           {
	//			if (currentTarget != null)
	//			{
	//				currentTarget.OnEndHover();
	//				currentTarget = null;
	//				return;
	//			}
	//		}
	//       }
	//	else
	//       {
	//		if (currentTarget != null)
	//		{
	//			currentTarget.OnEndHover();
	//			currentTarget = null;
	//			return;
	//		}
	//	}
	//   }

}
