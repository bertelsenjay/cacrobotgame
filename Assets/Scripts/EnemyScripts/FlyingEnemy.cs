using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

public class FlyingEnemy : MonoBehaviour
{

    AIPath path;
    public GameObject player; 
    public float closeDistance; 

    private void Awake()
    {
        path = GetComponent<AIPath>();
    }
    // Start is called before the first frame update
    void Start()
    {
        path.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        float playerDistance = playerDirection.magnitude;
        playerDirection.Normalize();
        if (playerDistance <= closeDistance)
        {
            path.canMove = true;
        }
        else
        {
            path.canMove = false;
        }
    }
}
