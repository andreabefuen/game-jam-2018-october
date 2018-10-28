﻿using UnityEngine;

public class Level : MonoBehaviour
{
    public int numberOfEnemies;
    public int levelSeconds;


    void Start()
    {
        GameManager.instance.numberOfTotalEnemies = numberOfEnemies;
        GameManager.instance.numberOfTotalEnemies = numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

}
