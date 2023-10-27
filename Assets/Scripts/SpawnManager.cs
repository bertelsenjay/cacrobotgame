using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public static int spawnIndex;
    public GameObject player;
    private void Start()
    {
        player.transform.position = spawnPoints[spawnIndex].transform.position;
    }
}
