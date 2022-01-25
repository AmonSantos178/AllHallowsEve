using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePanelBehaviour : MonoBehaviour
{
    CanvasGroup cg;
    bool fading;
    [SerializeField] Animator anim;
    Button[] menuButtons;
    
    void Start()
    {
        fading = false;
        cg = GetComponent<CanvasGroup>();
        menuButtons = GetComponentsInChildren<Button>();
        cg.alpha = 0f;
        foreach(Button button in menuButtons)
        {
            button.gameObject.SetActive(false);
        }
        StartCoroutine(BecomeVisible(10f));
    }

    void Update()
    {
        if(fading)
        {
            cg.alpha += 0.01f;
        }
    }

    IEnumerator BecomeVisible(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        fading = true;
        anim.SetTrigger("TitleTrigger");
        foreach (Button button in menuButtons)
        {
            button.gameObject.SetActive(true);
        }
    }
}
