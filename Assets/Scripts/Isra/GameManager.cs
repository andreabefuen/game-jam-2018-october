using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    /*  Funciones públicas del GameManager
     * 
     *  Función más importante: SetupLevel()
     *      Prepara el GameManager con el número del nivel, el timer, el número de enemigos...
     *      Carga el prefab del nivel y empieza el juego.
     * 
     * 
     */


    [Header("Lista de prefabs de niveles")]
    public GameObject[] levels;
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

    public Animation directionalLightRGBAnimation;

    void LoadLevel(int levelNumber) { currentLevelPrefab = Instantiate(levels[levelNumber], Vector3.zero, Quaternion.identity); }

    void Restart()
    {
        doorOpenPercentage = 0;
        numberOfEnemiesSaved = 0;
    }

    public void SetupLevel(int levelNumber, float levelSeconds)
    {
        directionalLightRGBAnimation.Stop();
        directionalLightRGBAnimation.GetComponent<Light>().color = Color.white;

        // Set the level number and the graphics
        this.levelNumber = levelNumber;

        // Set the internal variables
        this.levelSeconds = levelSeconds;

        // If there is a level instantiated, destroy it
        if (currentLevelPrefab != null) Destroy(currentLevelPrefab);

        // Initialize the graphics for the timer
        UIController.InitializeTimer(levelSeconds);


        Restart();

        // Load the prefab of the level
        LoadLevel(levelNumber);

    }


    public void StartTimer() { timerActivated = true; }
    //public void GetNumberOfEnemies() { numberOfTotalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length; }
    public void OnEnemySaved()
    {
        if(numberOfEnemiesSaved < numberOfTotalEnemies && levelSeconds > 0)
        {
            numberOfEnemiesSaved++;
            doorOpenPercentage = (int)(numberOfEnemiesSaved / numberOfTotalEnemies * 100);

        }
        if (numberOfEnemiesSaved == numberOfTotalEnemies)
        {
            directionalLightRGBAnimation.Play();
            timerActivated = false;
        }

    }

    public void OnEnemyRemoved(int number)
    {
        numberOfEnemiesSaved-= number;
        doorOpenPercentage = (int)(numberOfEnemiesSaved / numberOfTotalEnemies * 100);
    }

    void RestartLevel()
    {
        SetupLevel(levelNumber, levels[levelNumber].GetComponent<Level>().levelSeconds);
    }

    void SetupNewLevel()
    {
        SetupLevel(levelNumber, levels[levelNumber].GetComponent<Level>().levelSeconds);
    }

    public void OnLevelCompleted()
    {
        UIController.ShowLevelComplete();
        levelNumber++;
        Invoke("SetupNewLevel", 0.5f);
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
        SetupLevel(levelNumber, levels[levelNumber].GetComponent<Level>().levelSeconds);
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (timerActivated) { DecrementTimer(); }
    }
}
