using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 4.0f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    


    AudioSource aud;
    
    bool isTransitioning = false;



    void Start()
    {
        aud = GetComponent<AudioSource>();   
    }


    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;
        switch(other.gameObject.tag)
        {
            case "Fuel" :
                Debug.Log("d");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Friendly":
                break;
            default :
                StartCrashSequence();
        
                break;

        }   
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        aud.Stop();
        aud.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        successParticle.Play();
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;      
        aud.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        crashParticle.Play();
        Invoke("ReloadLevel",levelLoadDelay);

    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }


    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);  
    }

    



}
