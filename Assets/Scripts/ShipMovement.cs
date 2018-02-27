using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]

public class ShipMovement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;


    private AudioClip engineAudioClip;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float thrustSpeed = 1000f;

    public AudioClip EngineAudioClip;


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = EngineAudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
        Rotate();
    }


    void PlayerInputs()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }

        }
        else
        {
            audioSource.Stop();
        }


    }


    void Rotate()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        rb.freezeRotation = false;

    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Danger":
                {
                    print("Take Damage");
                    break;
                }





            default:
                {
                    print("It's Okay");
                    break;
                }
        }
    }

}
