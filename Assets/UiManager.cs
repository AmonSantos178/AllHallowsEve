using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    float currentScale;
    void Start()
    {
        currentScale = Time.timeScale;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                currentScale = Time.timeScale;
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = currentScale;
            }
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void closePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = currentScale;
    }
}
