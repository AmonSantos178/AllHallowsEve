using System;
using UnityEngine;

public class CameraRegulator : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    float xLimit = 60;
    float yLimit = 69;
    float cameraDistance = -10;

    float xPos;
    float yPos;

    void Start()
    {
        transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y, cameraDistance);
    }

    void Update()
    {
        xPos = Mathf.Clamp(playerLocation.position.x, -xLimit, xLimit);
        yPos = Mathf.Clamp(playerLocation.position.y, -yLimit, yLimit);

        transform.position = new Vector3(xPos, yPos, cameraDistance);
    }
}
