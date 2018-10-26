using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionsMovements : MonoBehaviour
{
    NavMeshAgent nav;
    public Color colorOfMinion;
    //public Transform target;
    public float speed;

    Vector3 startPosition;
    
    

    // Start is called before the first frame update
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;

        nav.SetDestination(GetRandomTarget());

        startPosition = this.transform.position;
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

    private void OnCollisionEnter(Collision collision)
    {
        if ((colorOfMinion == Color.red && collision.collider.name == "GoalRed")
            ||
            (colorOfMinion == Color.yellow && collision.collider.name == "GoalYellow")
            ||
            (colorOfMinion == Color.blue && collision.collider.name == "GoalBlue")
            ||
            (colorOfMinion == Color.green && collision.collider.name == "GoalGreen"))
        {
            nav.SetDestination(startPosition);
        }



    }

    // Update is called once per frame
    void Update()
    {

        //nav.SetDestination(target.position);

        
        

        if (nav.remainingDistance == 0)
        {

            
           
           
             nav.SetDestination(GetRandomTarget());
            


            

      
        }
        
        
    }
}
