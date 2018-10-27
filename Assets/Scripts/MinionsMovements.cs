using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionsMovements : MonoBehaviour
{
    NavMeshAgent nav;
    public PlayerMovement.Colores colorOfMinion;
    public Transform player;
    //public Transform target;
    public float speed;

    public Animator anim;

    public float enemyDistanceRun;

    Vector3 startPosition;
    Transform startTransform;

    public float nextPosDistance;
    Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;

       // anim = GetComponent<Animator>();

        //nav.SetDestination(GetRandomTarget());

        startPosition = this.transform.position;

        anim.SetBool("isRunning", true);

    }

    Vector3 GetRandomTarget()
    {

        nextPosition = transform.position + new Vector3(Random.Range(-nextPosDistance, nextPosDistance), 0, Random.Range(-nextPosDistance, nextPosDistance));
        return nextPosition;
    }

    void RunAway()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if ((colorOfMinion == PlayerMovement.Colores.Red && other.name == "GoalRed")
           ||
           (colorOfMinion == PlayerMovement.Colores.Yellow && other.name == "GoalYellow")
           ||
           (colorOfMinion == PlayerMovement.Colores.Blue && other.name == "GoalBlue")
           ||
           (colorOfMinion == PlayerMovement.Colores.Green && other.name == "GoalGreen"))
        {
            anim.SetBool("isRunning", false);
            nav.isStopped = true;
            //Debug.Log("pene");
        }

        else
        {
            nav.SetDestination(startPosition);
        }


    }

    // Update is called once per frame
    void Update()
    {

        //nav.SetDestination(target.position);

       
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist < enemyDistanceRun && colorOfMinion == player.GetComponent<PlayerMovement>().colorNow)
            {
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
