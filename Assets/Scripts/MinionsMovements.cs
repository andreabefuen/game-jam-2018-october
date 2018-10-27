﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionsMovements : MonoBehaviour
{
    NavMeshAgent nav;
    public Color colorOfMinion;
    public Transform player;
    //public Transform target;
    public float speed;

    public float enemyDistanceRun = 20.0f;

    Vector3 startPosition;
    Transform startTransform;


    

    // Start is called before the first frame update
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;

        //nav.SetDestination(GetRandomTarget());

        startPosition = this.transform.position;

        colorOfMinion = Color.yellow;
    }

    Vector3 GetRandomTarget()
    {

        Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));

        Vector3 distance = transform.position - position;
        while (distance.sqrMagnitude < 10)
        {
            position = GetRandomTarget();
        }
        return position;


    }

    void RunAway()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if ((colorOfMinion == Color.red && other.name == "GoalRed")
           ||
           (colorOfMinion == Color.yellow && other.name == "GoalYellow")
           ||
           (colorOfMinion == Color.blue && other.name == "GoalBlue")
           ||
           (colorOfMinion == Color.green && other.name == "GoalGreen"))
        {

            nav.isStopped = true;
            //Debug.Log("pene");
        }

       //if(other.tag == "Player")
       //{
       //    Debug.Log("me voy");
       //    RunAway();
       //}
    }

    // Update is called once per frame
    void Update()
    {

        //nav.SetDestination(target.position);

        float dist = Vector3.Distance(transform.position, player.transform.position);

       // Debug.Log(dist);

        if (dist < enemyDistanceRun)
        {
            //Debug.Log("me voy");

            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

           // nav.acceleration = 5f;

            nav.SetDestination(newPos);
        }

       else if (nav.remainingDistance == 0)
        {

                nav.SetDestination(GetRandomTarget());

        }
        
       
        
        
    }
}
