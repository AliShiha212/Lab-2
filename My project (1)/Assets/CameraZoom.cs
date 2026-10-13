using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    public float ZoomSpeed = 5f;
    public float MinZoom = 2f;
    public float MaxZoom = 10f;

    private float TargetZoom;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        TargetZoom = cam.orthographicSize;
    }

    void Update()
    {
        float ScrollData = Input.GetAxis("Mouse ScrollWheel");

        TargetZoom -= ScrollData * ZoomSpeed;

        TargetZoom = Mathf.Clamp(
            TargetZoom,
            MinZoom,
            MaxZoom
        );

        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            TargetZoom,
            ZoomSpeed * Time.deltaTime
        );
    }
}