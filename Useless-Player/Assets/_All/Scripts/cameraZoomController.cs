using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoomController : MonoBehaviour
{
    private Camera camZoom;
    private float targetZoom;
    public float zoomFactor;
    public float zoomLerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        camZoom = Camera.main;
        targetZoom = camZoom.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 4.5f, 8f);
        camZoom.orthographicSize = Mathf.Lerp(camZoom.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}
