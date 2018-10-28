using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNeon : MonoBehaviour
{
    public GameObject NeonON, NeonOff;

    void Start()
    {
        NeonOff.SetActive(true);
        NeonON.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.doorOpenPercentage == 100)
        {
            NeonOff.SetActive(false);
            NeonON.SetActive(true);
        }
    }
}
