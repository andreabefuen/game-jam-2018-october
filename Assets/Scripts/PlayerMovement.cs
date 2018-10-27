﻿using System.Collections;
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
    enum Colores {Red, Green, blue, Yellow, White }
    Colores colorNow;
    Color colorStart;
    Color newColor;
    bool changeColor;
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
                        Debug.Log("Entro");
                    }
                    break;
                case "GoalYellow":

                    break;
                case "GoalGreen":

                    break;
                case "GoalBlue":

                    break;
            }
        }
    }
}
