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
    public void EnemiesEscapeZone()
    {
        GameManager.instance.OnEnemyRemoved(EnemiesSaved.Count);
        foreach (GameObject Enemy in EnemiesSaved)
        {
            Enemy.GetComponent<MinionsMovements>().Escape();
        }
        EnemiesSaved.Clear();
        //Debug.Log(EnemiesSaved.Count);
        
    }
}
