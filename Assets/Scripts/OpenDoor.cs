using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    float OpenPerce,BasePosition, time;

    // Start is called before the first frame update
    void Start()
    {
        OpenPerce = 0;
        BasePosition = transform.position.y;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenPerce != GameManager.instance.doorOpenPercentage)
        {
            UpdateDoor();
        }
        
    }
    void UpdateDoor()
    {
        time += Time.deltaTime;

        
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Lerp(transform.position.y, BasePosition + ((BasePosition * GameManager.instance.doorOpenPercentage) / 100f)*2, time);
        transform.position = newPosition;
        if (time >= 1)
        {
            if (GameManager.instance.doorOpenPercentage == 100)
            {
                GetComponent<BoxCollider>().enabled = false;
            }
            OpenPerce = GameManager.instance.doorOpenPercentage;
            time = 0;
        }
    }
}
