using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public float maxSpeed;

    public float acceleration;

    public bool isMoving;

    public float totalRotationY;
    public float totalRotationX;
    public float sensitivity;

    public Transform CameraJoint;
    
    // Update is called once per frame
    void Update()
    {
        Transform charTransform = GetComponent<Transform>();


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) &&
            !Input.GetKey(KeyCode.W))
            isMoving = false;
        
        if (!isMoving)
            speed = 0;
        

        //Üst düzey değişikliker 
        if (Input.GetKey(KeyCode.A))
        {
            
            charTransform.position += charTransform.right * (-1 * (speed * Time.deltaTime));
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            charTransform.position += charTransform.right * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            charTransform.position += charTransform.forward * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            charTransform.position += charTransform.forward * (-1 * speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }


        
        float deltaRotationY = Input.GetAxis("Mouse X");
        totalRotationY += deltaRotationY * sensitivity * Time.deltaTime;

        float deltaRotationX = Input.GetAxis("Mouse Y");
        totalRotationX += deltaRotationX * sensitivity * Time.deltaTime;

        totalRotationX = Mathf.Clamp(totalRotationX, -50, 30);
        
        charTransform.rotation = Quaternion.Euler(0, totalRotationY,0);
        CameraJoint.localRotation = Quaternion.Euler(totalRotationX, 0, 0);
        
        
    }
}
