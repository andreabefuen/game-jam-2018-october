using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZoneScript : MonoBehaviour
{

    List<GameObject> EnemiesSaved = new List<GameObject>();
 
    // Update is called once per frame
    public void EnemieEnterSave(GameObject Enemy)
    {
        EnemiesSaved.Add(Enemy);
        GameManager.instance.OnEnemySaved();
    }
    public void EnemieEscape()
    {/*
        GameManager.instance.numberOfEnemiesSaved -= EnemiesSaved.Count;
        foreach (GameObject Enemy in EnemiesSaved)
        {
        }
        EnemiesSaved.Clear();
        //Debug.Log(EnemiesSaved.Count);
        */
    }
}
