using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePanelBehaviour : MonoBehaviour
{
    CanvasGroup cg;
    bool fading;
    [SerializeField] Animator anim;
    void Start()
    {
        fading = false;
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0f;
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
    }
}
