using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject highlighter;
    public int menuIndex = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HandleInput()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            menuIndex = 0;
            MoveHighlighter();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            menuIndex = 1;
            MoveHighlighter();
        }        
    }

    void MoveHighlighter()
    {
        if(menuIndex == 0)
        {
            highlighter.GetComponent<RectTransform>().anchoredPosition = new Vector3(81.2f, -77.56f, 0);
        }
        else
        {
            highlighter.GetComponent<RectTransform>().anchoredPosition = new Vector3(81.2f, -152.56f, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput(); 
    }
}
