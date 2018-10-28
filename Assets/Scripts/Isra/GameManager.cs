using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    #region Variable references
    public static GameManager instance;
    bool firstTime = true;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);

    }
    [HideInInspector] public UIController UIController;
    #endregion

    [Header("Current level variables")]
    public int levelNumber = 1;
    public float numberOfTotalEnemies;
    public float numberOfEnemiesSaved;
    public int doorOpenPercentage = 0;

    [Header("Timer")]
    public float levelSeconds;
    private bool timerActivated = false;


    public Animation directionalLightRGBAnimation;

    void ProceedToNextLevel()
    {
        levelNumber++;
        SceneManager.LoadScene(levelNumber);
        UIController.instance.HideLevelComplete();
        Restart();
        directionalLightRGBAnimation.Stop();
        directionalLightRGBAnimation.GetComponent<Light>().color = Color.white;

    }

    void Restart()
    {
        doorOpenPercentage = 0;
        numberOfEnemiesSaved = 0;
    }

    void Start()
    {
        levelNumber = 1;
    }

    public void StartTimer() { timerActivated = true; }
    //public void GetNumberOfEnemies() { numberOfTotalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length; }
    public void OnEnemySaved()
    {
        if(numberOfEnemiesSaved < numberOfTotalEnemies)
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


    public void OnLevelCompleted()
    {
        UIController.ShowLevelComplete();
        ProceedToNextLevel();
    }

    void OnGameOver()
    {
        levelSeconds = 0;
        UIController.ShowInformationText("Game over!", Mathf.Infinity);
    }

    void DecrementTimer()
    {
        if (levelSeconds > 0) levelSeconds -= Time.deltaTime;
        else OnGameOver();
        UIController.UpdateTimerGraphic(levelSeconds);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) ProceedToNextLevel();
    }
}
