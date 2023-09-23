using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float rotationSpeed; //Set to 150f in inspector
    private float swapper;
    private float tempSpeed = 0; //swapping values with this variable

    public float forwardForce = 100.0f;
    private Rigidbody2D tankRb;


    void Start(){
        tankRb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump")){
            swapper = rotationSpeed;
        }
        else if(Input.GetButton("Jump")){
            Vector3 direction = Quaternion.Euler(0.0f,0.0f,transform.rotation.z) * Vector2.up;
            rotationSpeed = tempSpeed;
            transform.Translate(direction * forwardForce * Time.deltaTime);
        }
        else if(Input.GetButtonUp("Jump")){
            rotationSpeed = swapper *-1;
        }   
        transform.Rotate(0.0f,0.0f,rotationSpeed * Time.deltaTime);
    }
}
