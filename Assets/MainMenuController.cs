using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject highlighter;
    public int menuIndex = 0;
    bool playedMenuSFX = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void RestartPlayedMenuSFX()
    {
        playedMenuSFX = false;
    }

    void HandleInput()
    {
        if (Input.GetAxis("Vertical") > 0 && menuIndex != 0)
        {
            menuIndex = 0;
            if (!playedMenuSFX)
            {
                GetComponent<AudioSource>().Play();
                playedMenuSFX = true;
            }
            MoveHighlighter();
        }
        else if (Input.GetAxis("Vertical") < 0 && menuIndex != 1)
        {
            menuIndex = 1;
            if (!playedMenuSFX)
            {
                GetComponent<AudioSource>().Play();
                playedMenuSFX = true;
            }
            MoveHighlighter();
        }

        if(menuIndex == 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Submit") > 0))
        {
            SceneManager.LoadScene(1);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }

    void MoveHighlighter()
    {
        if(menuIndex == 0)
        {
            highlighter.GetComponent<RectTransform>().anchoredPosition = new Vector3(81.2f, -77.56f, 0);
            Invoke("RestartPlayedMenuSFX", Time.deltaTime);

        }
        else
        {
            highlighter.GetComponent<RectTransform>().anchoredPosition = new Vector3(81.2f, -152.56f, 0);
            Invoke("RestartPlayedMenuSFX", Time.deltaTime);
        }

    }
    // Update is called once per frame
    void Update()
    {
        HandleInput(); 
    }
}
