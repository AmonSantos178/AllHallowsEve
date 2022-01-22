using System;
using UnityEngine;

public class CameraRegulator : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    float eastBorder = 60;
    float westBorder = -60;
    float southBorder = -69;
    float northBorder = 69;
    float cameraDistance = -10;

    float xPos;
    float yPos;

    void Start()
    {
        transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y, cameraDistance);
    }

    void Update()
    {
        xPos = Mathf.Clamp(playerLocation.position.x, westBorder, eastBorder);
        yPos = Mathf.Clamp(playerLocation.position.y, southBorder, northBorder);

        transform.position = new Vector3(xPos, yPos, cameraDistance);
    }
}
