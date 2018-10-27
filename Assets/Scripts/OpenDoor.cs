using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    float OpenPerce, BaseScale, BasePosition, time, initPosition, initScale;

    // Start is called before the first frame update
    void Start()
    {
        OpenPerce = 0;
        BaseScale = 1.25f;
        BasePosition = 0.625f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenPerce != GameManager.instance..doorOpenPercentage)
        {
            UpdateDoor();
        }
        
    }
    void UpdateDoor()
    {
        time += Time.deltaTime;

        Vector3 Scale = transform.localScale;
        Scale.y = Mathf.Lerp(transform.localScale.y, BaseScale - (BaseScale * GameManager.instance..doorOpenPercentage) / 100f, time);
        
        transform.localScale = Scale;
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Lerp(transform.position.y, BasePosition + (((BaseScale/2) * GameManager.instance..doorOpenPercentage) / 100f), time);
        gameObject.transform.position = newPosition;
        if (time >= 1)
        {
            if (GameManager.instance..doorOpenPercentage == 100)
            {
                Destroy(this.gameObject);
            }
            OpenPerce = GameManager.instance..doorOpenPercentage;
            time = 0;
        }
    }
}
