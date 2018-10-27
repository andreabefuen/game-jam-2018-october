using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZoneScript : MonoBehaviour
{
    List<GameObject> EnemiesSaved = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    public void EnemieEnterSave(GameObject Enemy) {
        EnemiesSaved.Add(Enemy);
        Debug.Log(EnemiesSaved.Count);
        GameManager.instance.OnEnemySaved();
    }
    public void EnemieEscape()
    {
        GameManager.instance.numberOfEnemiesSaved -= EnemiesSaved.Count;
        foreach (GameObject Enemy in EnemiesSaved)
        {
          //  Enemy.GetComponent<MinionsMovements>().RunAway();
        }
        EnemiesSaved.Clear();
        Debug.Log(EnemiesSaved.Count);

    }
}
