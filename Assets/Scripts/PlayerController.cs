using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public float maxSpeed;

    public float acceleration;

    public bool isMoving;

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
            
            charTransform.position += Vector3.left * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            charTransform.position += Vector3.right * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            charTransform.position += Vector3.forward * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            charTransform.position += Vector3.back * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
    }
}
