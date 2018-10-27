using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{

    GameManager GMScript;
    // Start is called before the first frame update
    void Start()
    {
        GMScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        GMScript.Invoke("OnLevelCompleted", 0.5f);
    }
}
