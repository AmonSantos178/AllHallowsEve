using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    Camera cam;
    bool moving = false;
    float yPos;
    float yWalk = 0.04f;
    void Start()
    {
        Time.timeScale = 1f;
        moving = false;
        cam = Camera.main;
        yPos = cam.transform.position.y;
        cam.transform.position = new Vector3(0f, -64f, -10f);
        StartCoroutine(StartMoving(1.5f));
    }

    void Update()
    {
        if(moving)
        {
            yPos = Mathf.Clamp(cam.transform.position.y + yWalk, -64f, 60f);
            cam.transform.position = new Vector3(cam.transform.position.x, yPos, -10f);
        }
    }

    IEnumerator StartMoving(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        moving = true;
    }
}
