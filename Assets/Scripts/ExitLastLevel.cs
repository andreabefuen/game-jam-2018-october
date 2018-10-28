using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLastLevel : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.doorOpenPercentage == 100)
            {
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
            particles.SetActive(true);
        }
    }
}
