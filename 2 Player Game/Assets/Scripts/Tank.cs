using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float rotateSpeed;

    private void Start(){

    }

    private void Update(){
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime); //this code rotates the tank
    }
}
