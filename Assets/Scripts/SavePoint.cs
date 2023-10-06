using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    public static int saveIndex;
    //public int initialSaveIndex = 0;
    public Transform position;
    private GameObject target;
    public static bool hasSaved = false;
    // Start is called before the first frame update
    void Start()
    {
        /*switch (saveIndex)
        {
            case 0:
                if (hasSaved)
                {
                    Debug.Log("transform set");
                    target.transform.position = position.transform.position;

                }
                break;
        }*/
        //saveIndex = initialSaveIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasSaved = true;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            saveIndex = 0;
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            saveIndex = 1;
        }
        if (collision.gameObject.tag == "Player")
        {
            switch (saveIndex)
            {
                case 0:
                    Debug.Log("Index Set");
                    LevelLoader.savePointIndex = 0;
                    target = collision.gameObject;
                    break;
                case 1:
                    LevelLoader.savePointIndex = 1;
                    break;

            }
        }
    }
}
