using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transitionPanel;
    public void LoadLevel(int i)
    {
        StartCoroutine(Load(i));
    }

    IEnumerator Load(int i)
    {
        transitionPanel.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(i);

    }
}
