using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public static int spawnIndex = 0;
    public GameObject player;
    private void Start()
    {
        player.transform.position = spawnPoints[spawnIndex].transform.position;
    }
    private void Update()
    {
        if (spawnIndex > spawnPoints.Length - 1)
        {
            //spawnIndex = 0;
        }
    }
}
