using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float rotationSpeed = 50f;
    void Update(){
        
        transform.Rotate(0.0f,0.0f,rotationSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")){
            rotationSpeed *= -1;
        }

        if(Input.GetKeyDown(KeyCode.G)){
            ShowCurrentRotation();
        }
    }

    private void ShowCurrentRotation(){
        Vector3 rotation = Quaternion.ToEulerAngles(transform.rotation);
        Debug.Log(rotation);
    }
}
