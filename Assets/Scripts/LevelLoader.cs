using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        LoadNextLevel();
    }
    void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }*/
    }

    void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(levelIndex);
    }

}
