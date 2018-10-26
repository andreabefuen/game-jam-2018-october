using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionsMovements : MonoBehaviour
{
    NavMeshAgent nav;
    //public Transform target;
    public float speed;
    
    

    // Start is called before the first frame update
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;

        nav.SetDestination(GetRandomTarget());

    }

    Vector3 GetRandomTarget()
    {

        Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));

        return position;




        
    }

    // Update is called once per frame
    void Update()
    {

        //nav.SetDestination(target.position);

        
        

        if (nav.remainingDistance == 0)
        {

            
            Vector3 random = GetRandomTarget();
            Vector3 distance = transform.position - random;

            while(distance.sqrMagnitude < 10)
            {
                random = GetRandomTarget();
            }

           
             nav.SetDestination(random);
            


            

      
        }
        
        
    }
}
