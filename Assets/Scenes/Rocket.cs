using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float rcsThruset = 15f;
    [SerializeField] float speedThrust = 30f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deadEngine;
    [SerializeField] AudioClip finishEngine;

    [SerializeField] ParticleSystem effectFly;
    [SerializeField] ParticleSystem effectSuccess;
    [SerializeField] ParticleSystem effectDead;
    int levelNow = 0;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            Thrust();
            Rotation();
            RocketEffects();
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Fine");
                    break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                print("Dead");
                StartDeathSequence();
                break;
        }
    }

    private void StartDeathSequence()
    {
        audioSource.Stop();
        state = State.Dying;
        effectDead.Play();
        audioSource.PlayOneShot(deadEngine);
        Invoke("LoadNextScene", 2f);
    }

    private void StartSuccessSequence()
    {
        audioSource.Stop();
        print(levelNow);
        state = State.Transcending;
        audioSource.PlayOneShot(finishEngine);
        effectSuccess.Play();
        Invoke("LoadNextScene", 2f);
        levelNow++;
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(levelNow);
    }



    private void RocketEffects()
    {
        if (Input.GetKey(KeyCode.Space) && state == State.Alive)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            effectFly.Play();
        }
        else
        {
            effectFly.Stop();
            audioSource.Stop();
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
