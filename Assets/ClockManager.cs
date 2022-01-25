using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    [SerializeField] Text clockText;
    [SerializeField] float currentTime;
    public bool running = true;
    DialogueManager dm;
    AudioSource ads;
    bool lostGame;

    private void Start()
    {
        lostGame = false;
        dm = FindObjectOfType<DialogueManager>();
        ads = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (running)
        {
            currentTime += Time.deltaTime / 2f;
            DisplayTime(currentTime);
            if (currentTime % 60 < 0.01)
            {
                ads.Play();
            }
        }

        if(currentTime >= 1080 && !lostGame)
        {
            lostGame = true;
            dm.SetUpDialogue("Mayor3");
        }
    }

    void DisplayTime(float time)
    {
        string ampm;
        if (time < 720)
        {
            ampm = "am";
        }
        else
        {
            ampm = "pm";
        }

        if (time > 780)
        {
            time -= 720;
        }

        float hours = Mathf.FloorToInt(time / 60);
        float minutes = Mathf.FloorToInt(time % 60);
        
        clockText.text = string.Format("{0:00}:{1:00} {2}", hours, minutes, ampm);

    }
}
