using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelLoader : MonoBehaviour
{
    public static bool isDead = false;
    public static bool localIsDead = false;
    public static int savePointIndex = 1;
    public int saveLevelIndex; 
    public Animator transition;
    Animator anim; 
    public float transitionTime = 2f;
    public float loadDelay = 0.5f;
    // Update is called once per frame
    private void Start()
    {
        isDead = false;
        localIsDead = false;
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        saveLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        
         //LoadNextLevel(); 
        if (localIsDead)
        {
            /*anim.SetBool("wallJump", false);
            anim.ResetTrigger("Dash");
            anim.SetBool("isSliding", false);
            anim.ResetTrigger("Attack");*/
            //Invoke("LoadLastSave", loadDelay);
            //anim.SetTrigger("isDead");
            LoadSavedLevel();
        }
    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(saveLevelIndex));
    }

    public void LoadSavedLevel()
    {
        PauseMenu.isPaused = false;
        StartCoroutine(LoadLevel(savePointIndex));
    }

    public void LoadNextLevel(int sceneIndex)
    {

        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(LoadLevel(sceneIndex));
        Debug.Log("Loading");
    }


    
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
