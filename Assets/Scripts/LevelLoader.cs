using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelLoader : MonoBehaviour
{
    public static bool isDead = false;
    public int saveLevelIndex; 
    public Animator transition;
    public float transitionTime = 2f;
    // Update is called once per frame
    private void Awake()
    {
        isDead = false; 
        saveLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        
         //LoadNextLevel(); 
        if (isDead)
        {
            LoadLastSave();
        }
    }
    public void LoadLastSave()
    {
        StartCoroutine(LoadLevel(saveLevelIndex));
    }

    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
