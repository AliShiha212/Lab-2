using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float CameraSpeed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 newPosition = Vector2.Lerp(
                transform.position,
                target.position,
                CameraSpeed * Time.fixedDeltaTime
            );

            float ClampX = Mathf.Clamp(newPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}