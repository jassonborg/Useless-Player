using UnityEngine;

public class LoadingMoney : MonoBehaviour
{
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.position);
    }
}
