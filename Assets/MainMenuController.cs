using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject highlighter;
    public int menuIndex = 0;

    bool canStart = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AllowStart", 1.5f);
    }

    void AllowStart()
    {
        canStart = true;
    }



    void HandleInput()
    {

        if(menuIndex == 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Submit") > 0) && canStart)
        {
            SceneManager.LoadScene(1);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    void Update()
    {
        HandleInput(); 
    }
}
