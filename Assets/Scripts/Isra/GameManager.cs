﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Lista de prefabs de niveles")]
    public GameObject[] levelPrefabs;
    GameObject currentLevelPrefab;

    #region Variable references
    public static GameManager instance;
    void Awake() { instance = this; }
    [HideInInspector] public UIController UIController;
    #endregion

    [Header("Current level variables")]
    public int levelNumber;
    public float numberOfTotalEnemies;
    public float numberOfEnemiesSaved;
    public int doorOpenPercentage;

    [Header("Timer")]
    public float levelSeconds;
    private bool timerActivated = false;

    
    void LoadLevel(int levelNumber)
    {
        currentLevelPrefab = Instantiate(levelPrefabs[levelNumber], Vector3.zero, Quaternion.identity);
    }

    void Restart()
    {
        doorOpenPercentage = 0;
        numberOfEnemiesSaved = 0;
    }

    public void SetupLevel(int levelNumber, float levelSeconds, int numberOfTotalEnemies)
    {
        // Restart the variables
        Restart();

        // Set the level number and the graphics
        this.levelNumber = levelNumber;
        UIController.UpdateLevelText(levelNumber);

        // Set the internal variables
        this.levelSeconds = levelSeconds;
        this.numberOfTotalEnemies = numberOfTotalEnemies;

        // If there is a level instantiated, destroy it
        if (currentLevelPrefab != null) Destroy(currentLevelPrefab);

        // Initialize the graphics for the timer
        UIController.InitializeTimer(levelSeconds);

        // Load the prefab of the level
        LoadLevel(levelNumber);

    }


    public void StartTimer() { timerActivated = true; }
    public void GetNumberOfEnemies() { numberOfTotalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length; }
    public void OnEnemySaved()
    {
        if(numberOfEnemiesSaved < numberOfTotalEnemies && levelSeconds > 0)
        {
            numberOfEnemiesSaved++;
            doorOpenPercentage = (int) (numberOfEnemiesSaved / numberOfTotalEnemies * 100);
            if (doorOpenPercentage == 100)
            {
                UIController.ShowLevelComplete();
                Invoke("OnLevelCompleted", 0.5f);
            }
        }
    }

    void OnLevelCompleted()
    {
        timerActivated = false;
        levelNumber++;
        SetupLevel(levelNumber, levelPrefabs[levelNumber].GetComponent<Level>().levelSeconds, levelPrefabs[levelNumber].GetComponent<Level>().numberOfEnemies);
        UIController.Invoke("HideLevelComplete", 1f);
        Invoke("StartTimer", 1.5f);
    }

    void OnGameOver()
    {
        levelSeconds = 0;
        UIController.ShowInformationText("Game over!", Mathf.Infinity);
    }

    void Start()
    {
        SetupLevel(levelNumber, levelPrefabs[levelNumber].GetComponent<Level>().levelSeconds, levelPrefabs[levelNumber].GetComponent<Level>().numberOfEnemies);
        StartTimer();
    }

    void DecrementTimer()
    {
        if (levelSeconds > 0) levelSeconds -= Time.deltaTime;
        else OnGameOver();

        UIController.UpdateTimerGraphic(levelSeconds);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { OnEnemySaved(); }
        if (timerActivated) { DecrementTimer(); }
    }
}