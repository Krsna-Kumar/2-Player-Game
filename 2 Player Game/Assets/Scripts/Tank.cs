using System;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float rotationSpeed; //Set to 150f in inspector
    private float swapper;
    private float tempSpeed = 0; //swapping values with this variable

    public GameObject bulletPrefab;

    public Transform launcherPoint;
    public float forwardForce = 100.0f;
    

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            FiringBullet();
            SwapSpeedValue();
        }

        else if(Input.GetMouseButton(0)){
            GoForward();
        }

        else if(Input.GetMouseButtonUp(0)){
            ReverseRotation();
        }

        //Rotate Object Constantly
        RotateObject();
    }

    private void FiringBullet(){
        GameObject bullet = Instantiate(bulletPrefab, launcherPoint.position, launcherPoint.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            
            bulletRigidbody.velocity = launcherPoint.up * forwardForce * 5;
            Destroy(bullet, 2f);
    }

    private void SwapSpeedValue(){
        swapper = rotationSpeed;
    }

    private void RotateObject(){
        transform.Rotate(0.0f,0.0f,rotationSpeed * Time.deltaTime);
    }

    private void ReverseRotation(){
            rotationSpeed = swapper *-1;
    }

    private void GoForward(){
        Vector3 direction = Quaternion.Euler(0.0f,0.0f,transform.rotation.z) * Vector2.up;
            
            rotationSpeed = tempSpeed;
            transform.Translate(direction * forwardForce * Time.deltaTime);
    }
}
