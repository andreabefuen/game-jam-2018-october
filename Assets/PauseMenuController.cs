using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject menuParent;

    bool showingMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!showingMenu)
            {
                showingMenu = true;
                menuParent.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Application.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (showingMenu)
            {
                showingMenu = false;
                menuParent.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (showingMenu)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
