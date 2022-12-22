using System;
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

    public Transform cameraJoint;
    public Transform charTransform;
    public Transform bulletSpawnPoint;

    public GameObject bullet;
    
    public float powerOfForwardForce = 500;
    public float powerOfUpForce = 100;

    public float bulletSpawnTime;
    public float timer;

    private void Start()
    {
        charTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheCharacter(charTransform);
        RotateCharacter(charTransform);


        timer += Time.deltaTime;

        if (timer > bulletSpawnTime)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = bulletSpawnPoint.position;

            Rigidbody rigidbodyOfBullet = spawnedBullet.GetComponent<Rigidbody>();
            rigidbodyOfBullet.AddForce(charTransform.forward * powerOfForwardForce + spawnedBullet.transform.up * powerOfUpForce);

            timer = 0;
        }
    }

    void RotateCharacter(Transform charTrans)
    {
        float deltaRotationY = Input.GetAxis("Mouse X");
        totalRotationY += deltaRotationY * sensitivity * Time.deltaTime;

        float deltaRotationX = Input.GetAxis("Mouse Y");
        totalRotationX += deltaRotationX * sensitivity * Time.deltaTime;

        totalRotationX = Mathf.Clamp(totalRotationX, -50, 30);
        
        charTrans.rotation = Quaternion.Euler(0, totalRotationY,0);
        cameraJoint.localRotation = Quaternion.Euler(totalRotationX, 0, 0);
    }

    void MoveTheCharacter(Transform charTrans)
    {
        

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) &&
            !Input.GetKey(KeyCode.W))
            isMoving = false;
        
        if (!isMoving)
            speed = 0;
        

        //Üst düzey değişikliker 
        if (Input.GetKey(KeyCode.A))
        {
            
            charTrans.position += charTrans.right * (-1 * (speed * Time.deltaTime));
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            charTrans.position += charTrans.right * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            charTrans.position += charTrans.forward * (speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            charTrans.position += charTrans.forward * (-1 * speed * Time.deltaTime);
            
            isMoving = true;
            if(speed < maxSpeed)
                speed += Time.deltaTime * acceleration;
        }
    }
}
