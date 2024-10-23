using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{

    public Animator animator;

    public float transitionTime = 1f;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void ChangeScene(string nameOfScene)
    {
        StartCoroutine(LoadScene(nameOfScene));
    }

    IEnumerator LoadScene(string scene)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scene);
    }
}
