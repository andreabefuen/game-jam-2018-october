using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.Invoke("OnLevelCompleted", 0.5f);
    }
}
