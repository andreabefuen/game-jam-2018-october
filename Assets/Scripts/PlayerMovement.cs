using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Light theLight;
    CapsuleCollider col;
    Rigidbody rBody;
    public float baseSpeed;
    public float speed = 15f;
    Vector3 velocity;
    float sizer, time;
    public enum Colores {Red, Green, Blue, Yellow, White }
    public Colores colorNow;
    Color colorStart;
    Color newColor;
    bool changeColor;

    public GameObject lightCone;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        theLight = GetComponent<Light>();
        colorNow = Colores.White;
        changeColor = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        rBody.velocity = transform.TransformDirection(velocity).normalized * speed;
        sizer = Input.GetAxis("SetSize");
        if (theLight.spotAngle < 75 && sizer > 0 || theLight.spotAngle > 20 && sizer < 0)
        {
            theLight.spotAngle += sizer;
            lightCone.transform.localScale += new Vector3(sizer*12, sizer*12, 0);
            theLight.intensity = theLight.spotAngle;
            col.radius += sizer * 0.16f;
            speed = baseSpeed / (theLight.spotAngle / 20);
        }
        if (changeColor)
        {
            time += Time.deltaTime / 2;
            theLight.color = Color.Lerp(colorStart, newColor, time);
            if(time >= 1)
            {
                changeColor = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ColorZone") {
            //if(other.gameObject.GetComponent<Renderer>().material.color == colorNow)
            switch(other.gameObject.name){
                case "GoalRed":
                    if(colorNow != Colores.Red)
                    {
                        time = 0;
                        colorStart = theLight.color;
                        newColor = Color.red;
                        changeColor = true;
                        colorNow = Colores.Red;
                        Debug.Log("Entro");
                    }
                    break;
                case "GoalYellow":
                    if (colorNow != Colores.Yellow)
                    {
                        time = 0;
                        colorStart = theLight.color;
                        newColor = Color.yellow;
                        changeColor = true;
                        colorNow = Colores.Yellow;
                        Debug.Log("Entro");
                    }
                    break;
                case "GoalGreen":
                    if (colorNow != Colores.Green)
                    {
                        time = 0;
                        colorStart = theLight.color;
                        newColor = Color.green;
                        changeColor = true;
                        colorNow = Colores.Green;
                        Debug.Log("Entro");
                    }
                    break;
                case "GoalBlue":
                    if (colorNow != Colores.Blue)
                    {
                        time = 0;
                        colorStart = theLight.color;
                        newColor = Color.blue;
                        changeColor = true;
                        colorNow = Colores.Blue;
                        Debug.Log("Entro");
                    }
                    break;
                case "GoalWhite":
                    if (colorNow != Colores.White)
                    {
                        time = 0;
                        colorStart = theLight.color;
                        newColor = Color.white;
                        changeColor = true;
                        colorNow = Colores.White;
                        Debug.Log("Entro");
                    }
                    break;
            }
        }
    }
}
