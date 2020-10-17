﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //member variables
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    AudioSource m_AudioSource;

    //public variables
    public float turnSpeed = 20f;
    public float shotSpeed = 10f;
    public GameObject projectilePrefab;
    public Transform shotSpawn;
   

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    //Called once every frame
    public void Update()
    {
        //if player presses space, fire a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //create projectile
            GameObject projectile = Instantiate(projectilePrefab, shotSpawn.transform.position, projectilePrefab.transform.rotation);
            //send projectile forward
            Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.velocity = transform.forward * shotSpeed;
        }
    }

    // FixedUpdate is called last once per frame
    void FixedUpdate()
    {
        //gathers input data from WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       
        //sets the movement vector to the input data and normalizes magnitude to 1
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();
       
        //detects movement and sets a bool accordingly that then sets the internal animator bool
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if(isWalking)
        {
            if(!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        //sets a rotation vector by returning mouse cursor''s posiiton and translating that into world position
        Vector2 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(mouseScreenPos.x,
            mouseScreenPos.y,
            Camera.main.transform.position.y - transform.position.y)
            );
        
        //gets vector leading from john to mouse pos
        Vector3 dirToMouse = mouseWorldPos - transform.position;
        dirToMouse = dirToMouse.normalized;

        //sets john's rotation to point to mouse location
        Vector3 desiredForward = Vector3.RotateTowards(dirToMouse, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    //applies movement and rotation
    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
