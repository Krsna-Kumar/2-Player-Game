using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Tank : MonoBehaviour
{
    public string buttomTagName;
    public ButtonEvent ownButton;
    public KeyCode tapButton;

    public float rotationSpeed; //Set to 150f in inspector
    private float swapper;
    private float tempSpeed = 0; //swapping values with this variable

    public GameObject bulletPrefab;

    public Transform launcherPoint;
    public float forwardForce = 100.0f;
    
    private void Start(){
        ownButton = GameObject.FindWithTag(buttomTagName).GetComponent<ButtonEvent>();
    }
    private void Update(){
        // if(Input.GetKeyDown(tapButton)){
        //     FiringBullet();
        //     SwapSpeedValue();
        // }

        // else if(Input.GetKey(tapButton)){
        //     GoForward();
        // }

        // else if(Input.GetKeyUp(tapButton)){
        //     ReverseRotation();
        // }

        if(ownButton.pointerDown){
            FiringBullet();
            SwapSpeedValue();
        }

        if(ownButton.pointerHold){
            GoForward();
        }

        if(ownButton.pointerRelease){
            ReverseRotation();
        }

        //Rotate Object Constantly
        RotateObject();
    }

    public void FiringBullet(){
        GameObject bullet = Instantiate(bulletPrefab, launcherPoint.position, launcherPoint.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            
            bulletRigidbody.velocity = launcherPoint.up * forwardForce * 5;
            Destroy(bullet, 2f);
    }

    public void SwapSpeedValue(){
        swapper = rotationSpeed;
    }

    public void RotateObject(){
        transform.Rotate(0.0f,0.0f,rotationSpeed * Time.deltaTime);
    }

    public void ReverseRotation(){
            rotationSpeed = swapper *-1;
    }

    public void GoForward(){
        Vector3 direction = Quaternion.Euler(0.0f,0.0f,transform.rotation.z) * Vector2.up;
            
            rotationSpeed = tempSpeed;
            transform.Translate(direction * forwardForce * Time.deltaTime);
    }
}
