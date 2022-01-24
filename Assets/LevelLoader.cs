using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transitionPanel;

    IEnumerator Load(int i)
    {
        transitionPanel.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(i);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(Load(0));
    }

    public void LoadGame()
    {
        StartCoroutine(Load(1));
    }

    public void CloseGame()
    {
        StartCoroutine(CloseThis());
    }

    IEnumerator CloseThis()
    {
        transitionPanel.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);
        Application.Quit();

    }
}
