using UnityEngine;
using UnityEngine.UI;

public class SMoneyPickup : MonoBehaviour, IInteractable
{
    //[SerializeField]
    //[Tooltip("How long it takes to pick up an item.")]
    //private float pickupTime = 2f;
    //[SerializeField]
    //[Tooltip("The root of the images (progress image should be a child of this too)")]
    //private RectTransform pickupImageRoot;
    //[SerializeField]
    //[Tooltip("The ring around the button that fills")]
    //private Image pickupProgressImage;

    //private float currentPickupTimerElapsed;
    public float MaxRange {  get { return maxRange; } }
    private const float maxRange = 5f;

    public void OnStartHover()
    {
        //pickupImageRoot.gameObject.SetActive(true);
        //Debug.Log($"{gameObject.name}");
        
    }
    public void OnInteract()
    {
        
    }

    public void OnEndHover()
    {
        //pickupImageRoot.gameObject.SetActive(false);
        //currentPickupTimerElapsed = 0f;
    }

    //private void IncrementPickupProgressAndTryComplete()
    //{
    //    currentPickupTimerElapsed += Time.deltaTime;
    //    if (currentPickupTimerElapsed >= pickupTime)
    //    {

    //    }
    //}

    //private void UpdatePickupProgressImage()
    //{
    //    float pct = currentPickupTimerElapsed / pickupTime;
    //    pickupProgressImage.fillAmount = pct;
    //}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
