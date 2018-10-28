using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject exitON;
    public GameObject exitOFF;

    public static ExitManager instance;
    void Awake() { instance = this; }

    void Start()
    {
        exitON.SetActive(false);
        exitOFF.SetActive(true);
    }

    public void ShowExit()
    {
        exitOFF.SetActive(false);
        exitON.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}