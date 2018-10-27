using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject ManagerObject;
    GameManager GMScript;
    float OpenPerce, BaseScale, BasePosition, time, initPosition, initScale;

    // Start is called before the first frame update
    void Start()
    {
        GMScript = ManagerObject.GetComponent<GameManager>();
        OpenPerce = 0;
        BaseScale = 1.25f;
        BasePosition = 0.625f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenPerce != GMScript.doorOpenPercentage)
        {
            UpdateDoor();
        }
    }
    void UpdateDoor()
    {
        time += Time.deltaTime;

        Vector3 Scale = transform.localScale;
        Scale.y = Mathf.Lerp(transform.localScale.y, BaseScale - (BaseScale * GMScript.doorOpenPercentage) / 100f, time);
        
        transform.localScale = Scale;
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Lerp(transform.position.y, BasePosition + (((BaseScale/2) * GMScript.doorOpenPercentage) / 100f), time);
        gameObject.transform.position = newPosition;
        if (time >= 1)
        {
            OpenPerce = GMScript.doorOpenPercentage;
            time = 0;
        }
    }
}
