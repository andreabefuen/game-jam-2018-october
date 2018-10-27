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

    public bool dancing;
    public bool activate = true;

    private bool insideHouse = false;

   
    // Start is called before the first frame update
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;

       // anim = GetComponent<Animator>();

        //nav.SetDestination(GetRandomTarget());

        startPosition = this.transform.position;
        //anim.SetTrigger("isWalking");
       // anim.SetBool("isWalking", true);
       // anim.SetBool("isRunning", false);
       // anim.SetBool("isDancing", false);

        if (dancing)
        {
            Debug.Log("A bailar");
            anim.SetTrigger("isDancing");
           // anim.SetBool("isRunning", false);
           // anim.SetBool("isWalking", false);
           // anim.SetBool("isDancing", true);
        }

    }

    Vector3 GetRandomTarget()
    {

        nextPosition = transform.position + new Vector3(Random.Range(-nextPosDistance, nextPosDistance), 0, Random.Range(-nextPosDistance, nextPosDistance));
        return nextPosition;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!insideHouse)
        {
            if ((colorOfMinion == PlayerMovement.Colores.Red && other.name == "GoalRed")
          ||
          (colorOfMinion == PlayerMovement.Colores.Yellow && other.name == "GoalYellow")
          ||
          (colorOfMinion == PlayerMovement.Colores.Blue && other.name == "GoalBlue")
          ||
          (colorOfMinion == PlayerMovement.Colores.Green && other.name == "GoalGreen")
          ||
          (colorOfMinion == PlayerMovement.Colores.White && other.name == "GoalWhite")
          )
            {

                Invoke("StopMinion", 0.5f);

                other.GetComponent<SaveZoneScript>().EnemieEnterSave(gameObject);


                //Debug.Log("pene");
            }

            else if ((colorOfMinion == PlayerMovement.Colores.Red && other.name != "GoalRed")
               ||
               (colorOfMinion == PlayerMovement.Colores.Yellow && other.name != "GoalYellow")
               ||
               (colorOfMinion == PlayerMovement.Colores.Blue && other.name != "GoalBlue")
               ||
               (colorOfMinion == PlayerMovement.Colores.Green && other.name != "GoalGreen")
               ||
               (colorOfMinion == PlayerMovement.Colores.White && other.name != "GoalWhite")
               )
            {
                nav.SetDestination(startPosition);
                anim.SetTrigger("isWalking");
                //anim.SetBool("isWalking", true);
                //anim.SetBool("isRunning", false);
                //anim.SetBool("isDancing", false);
                nav.speed = speed;
            }

            else
            {
                return;
            }
        }
        
       


    }

    void StopMinion()
    {

        insideHouse = true;
       //anim.SetBool("isRunning", false);
       //anim.SetBool("isWalking", false);
       //anim.SetBool("isDancing", false);

        nav.speed = 0;
        //anim.Play("Idle");
        anim.SetTrigger("isIdle");
        nav.enabled = false;

        //nav.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {

        //nav.SetDestination(target.position);

        if (!insideHouse && nav.enabled == true)
        {
            
            float dist = Vector3.Distance(transform.position, player.transform.position);

            //Si la distancia entre el player y el minion es menor que un cierto parámetro y además el color del haz de luz es igual al del minion
            if (dist < enemyDistanceRun && colorOfMinion == player.GetComponent<PlayerMovement>().colorNow)
            {
                Vector3 dirToPlayer = transform.position - player.transform.position;

                Vector3 newPos = transform.position + dirToPlayer;

                // nav.acceleration = 5f;

                //Si no esta bailando entonces CORRE
                if (!dancing)
                {

                    anim.SetTrigger("isRunning");
                   //anim.SetBool("isRunning", true);
                   //anim.SetBool("isWalking", false);
                   //anim.SetBool("isDancing", false);
                    nav.speed *= 2;
                    print("Salida 1");
                    nav.SetDestination(newPos);
                }
            }

            else if (nav.remainingDistance == 0 && activate)
            {

                if (!dancing)
                {
                    //anim.SetBool("isRunning", false);
                    //anim.SetBool("isWalking", true);
                    //anim.SetBool("isDancing", false);
                    anim.SetTrigger("isWalking");
                    print("Salida 2");
                    nav.speed /= 2;
                    nav.SetDestination(GetRandomTarget());
                }

            }

        }

        if (insideHouse)
        {
            StopMinion();
            
            anim.SetTrigger("isIdle");
            //anim.Play("Idle");
        }
    }
}
