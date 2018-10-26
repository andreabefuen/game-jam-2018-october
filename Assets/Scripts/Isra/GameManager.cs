using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variable references
    public static GameManager instance;
    public UIController UIController;
    #endregion

    public int levelNumber;
    public float numberOfTotalEnemies;
    public float numberOfEnemiesSaved;
    public int doorOpenPercentage;

    public float levelSeconds;
    private bool timerActivated = false;

    void Awake() { instance = this; }

    public void SetupLevel(int levelNumber, float levelSeconds, int numberOfTotalEnemies)
    {
        this.levelNumber = levelNumber;
        this.levelSeconds = levelSeconds;
        this.numberOfTotalEnemies = numberOfTotalEnemies;

        UIController.InitializeTimer(levelSeconds);

        Invoke("StartTimer", Time.deltaTime);
    }

    public void StartTimer() { timerActivated = true; }
    public void GetNumberOfEnemies() { numberOfTotalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length; }
    public void OnEnemySaved()
    {
        if(numberOfEnemiesSaved < numberOfTotalEnemies && levelSeconds > 0)
        {
            numberOfEnemiesSaved++;
            doorOpenPercentage = (int) (numberOfEnemiesSaved / numberOfTotalEnemies * 100);
            if (doorOpenPercentage == 100) OnLevelCompleted();
        }
    }

    void OnLevelCompleted()
    {
        timerActivated = false;
        Debug.Log("Level completed!");
    }


    void OnGameOver()
    {
        levelSeconds = 0;
        UIController.ShowInformationText("Sunomáh!", Mathf.Infinity);
    }

    void Start()
    {
        SetupLevel(1, 10, 3);
    }

    void DecrementTimer()
    {
        if (levelSeconds > 0) levelSeconds -= Time.deltaTime;
        else
        {
            OnGameOver();
        }

        UIController.UpdateTimerGraphic(levelSeconds);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { OnEnemySaved(); }
        if (timerActivated) { DecrementTimer(); }
    }

}
