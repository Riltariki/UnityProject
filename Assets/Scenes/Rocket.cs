using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float rcsThruset = 15f;
    [SerializeField] float speedThrust = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotation();
        ProcessSound();
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Fine");
                    break;
            case "Fuel":
                print("Fueld");
                break;
            default:
                print("Collided");
                break;
        }
    }
    private void ProcessSound()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Pause();
        }
    }
    private void Rotation()
    {
        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            print("Left rotating");
            float rotationSpeedFrame = rcsThruset * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationSpeedFrame);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float rotationSpeedFrame = rcsThruset * Time.deltaTime;
            transform.Rotate(-Vector3.forward * rotationSpeedFrame);
        }
        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float thrustSpeedFrame = speedThrust * Time.deltaTime;
            rigidBody.AddRelativeForce(Vector3.up * thrustSpeedFrame);
            print("Space pressed");
        }
    }
}
