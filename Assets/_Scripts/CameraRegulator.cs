using UnityEngine;

public class CameraRegulator : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    float eastBorder = 70;
    float westBorder = -70;
    float southBorder = -74;
    float cameraDistance = -15;

    void Start()
    {
        transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y, cameraDistance);
    }

    void Update()
    {
        if (playerLocation.position.x > eastBorder)
        {
            transform.position = new Vector3(eastBorder, playerLocation.position.y, cameraDistance);
        }
        else if (playerLocation.position.x < westBorder)
        {
            transform.position = new Vector3(westBorder, playerLocation.position.y, cameraDistance);
        }
        else if (playerLocation.position.y < southBorder)
        {
            transform.position = new Vector3(playerLocation.position.x, southBorder, cameraDistance);
        }
        else
        {
            transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y, cameraDistance);
        }
    }
}
