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


        startPosition = this.transform.position;


        if (dancing)
        {
            Debug.Log("A bailar");
            anim.SetTrigger("isDancing");

        }

    }

    Vector3 GetRandomTarget()
    {

        nextPosition = transform.position + new Vector3(Random.Range(-nextPosDistance, nextPosDistance), 0, Random.Range(-nextPosDistance, nextPosDistance));
        return nextPosition;
    }



    private void OnTriggerEnter(Collider other)
    {
        //Si no estan dentro de la casa y colisionan con el color
        if (!insideHouse && other.tag == "ColorZone")
        {
            //Si el color es el suyo
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
                //Se quedan en su casita y además aumenta el número de enemigos en su casita
                insideHouse = true;
                Invoke("StopMinion", 0.5f);

                other.GetComponent<SaveZoneScript>().EnemieEnterSave(gameObject);


            }

            //Si su color es diferente del que toca 
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
                    // No entra en esa casita y se va al centro
                    //Libera a los demás
                    nav.SetDestination(startPosition);
                    anim.SetTrigger("isWalking");
                    other.GetComponent<SaveZoneScript>().EnemiesEscapeZone();
                    nav.speed = speed;
                }

            else
            {
                return;
            }
        }
        
       


    }

    public void Escape()
    {
        nav.enabled = true;
        nav.speed = speed;
        nav.isStopped = false;
        anim.SetTrigger("isRunning");
        insideHouse = false;
        dancing = false;

        nav.SetDestination(startPosition);
        

    }

    void Stun()
    {
        anim.SetTrigger("isDancing");
        //dancing = true;
        nav.isStopped = true;

    }

    void StopMinion()
    {

        nav.speed = 0;

        anim.Play("Idle");
        nav.enabled = false;

    }

    void ResetMinion()
    {
        nav.speed = speed;
        nav.enabled = true;
        nav.isStopped = false;
        anim.SetTrigger("isWalking");

        nav.SetDestination(startPosition);
        
    }

    // Update is called once per frame
    void Update()
    {



        if (!insideHouse && nav.enabled == true)
        {
            
            float dist = Vector3.Distance(transform.position, player.transform.position);

            if(dist < enemyDistanceRun && colorOfMinion != player.GetComponent<PlayerMovement>().colorNow)
            {
                Stun();
            }

            //Si la distancia entre el player y el minion es menor que un cierto parámetro y además el color del haz de luz es igual al del minion
            else if (dist < enemyDistanceRun && colorOfMinion == player.GetComponent<PlayerMovement>().colorNow)
            {
                Vector3 dirToPlayer = transform.position - player.transform.position;

                Vector3 newPos = transform.position + dirToPlayer;

                nav.speed = speed;
                nav.isStopped = false;


                //Si no esta bailando entonces CORRE
                if (!dancing)
                {

                    anim.SetTrigger("isRunning");
         
                    nav.speed *= 2;
                    nav.SetDestination(newPos);
                }
            }

            else if (nav.remainingDistance == 0 && activate)
            {

                if (!dancing)
                {
                  
                    nav.speed = speed;
                    nav.isStopped = false;
                    anim.SetTrigger("isWalking");
                    nav.speed /= 2;
                    nav.SetDestination(GetRandomTarget());
                }

            }

        }
    }
}
