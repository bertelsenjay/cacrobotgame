using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public GameObject healthBar;
    public Enemy boss;
    public BossManager bossManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bossManager.GetLocalScale();
        if (HealthBar.scale <= 0)
        {
            healthBar.SetActive(false);
        }
        else if (HealthBar.scale > 0)
        {
            healthBar.SetActive(true);
        }
        
    }
}
