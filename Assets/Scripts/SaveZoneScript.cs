using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZoneScript : MonoBehaviour
{
    public GameObject GameManagerObject;
    GameManager GMScript;

    List<GameObject> EnemiesSaved = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {
        GMScript = GameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    public void EnemieEnterSave(GameObject Enemy) {
        EnemiesSaved.Add(Enemy);
        Debug.Log(EnemiesSaved.Count);
        GMScript.OnEnemySaved();
    }
    public void EnemieEscape()
    {
        GMScript.numberOfEnemiesSaved -= EnemiesSaved.Count;
        foreach (GameObject Enemy in EnemiesSaved)
        {
          //  Enemy.GetComponent<MinionsMovements>().RunAway();
        }
        EnemiesSaved.Clear();
        Debug.Log(EnemiesSaved.Count);

    }
}
