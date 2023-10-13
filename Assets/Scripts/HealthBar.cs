using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    //private Transform bar;
    public Enemy boss;
    public GameObject bar;
    public static float scale = 1f; 
    // Start is called before the first frame update
    private void Start()
    {
        //bar = transform.Find("Bar");
        //bar.localScale = new Vector3(.4f, 1f);
        //bar.transform.localScale = new Vector3(0.5f, 1f);
    }

    private void Update()
    {
        //Debug.Log("Current local scale " + boss.GetLocalScale());
        Debug.Log(scale);
        boss.GetLocalScale();
        bar.transform.localScale = new Vector3(scale, 1f);
        if (bar.transform.localScale.x <= 0f)
        {
            //bar.SetActive(false);
        }

    }
    public void SetSize(float sizeNormalized)
    {
        //bar.localScale = new Vector3(boss.GetLocalScale(), 1f);
    }
    
}
