using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] SFX;

    public AudioSource musicPlayer;
    public AudioClip[] songs;


    private void Awake()
    {
        Instance = this;
       
    }

    public void PlayAudio(string clipName,float volume = 1)
    {
        audioSource.volume = 1;
        switch (clipName)
        {
            
            case "meow":
                audioSource.PlayOneShot(SFX[0]);
                break;
            case "meow2":
                audioSource.PlayOneShot(SFX[1]);
                break;
            case "car":
                audioSource.PlayOneShot(SFX[2]);
                break;
            case "car2":
                audioSource.PlayOneShot(SFX[3]);
                break;
            case "horn":
                audioSource.PlayOneShot(SFX[4]);
                break;
            case "dog":
                audioSource.PlayOneShot(SFX[5]);
                break;
            case "dog2":
                audioSource.PlayOneShot(SFX[6]);
                break;
            case "collectStamina":
                audioSource.volume = 0.25f;
                audioSource.PlayOneShot(SFX[7]);
                break;
            case "collectFood":
                audioSource.volume = 0.55f;
                audioSource.PlayOneShot(SFX[8]);
                break;

        }


        
    }

    public void ChangeMusic(int i)
    {
        musicPlayer.clip = songs[i];
        musicPlayer.Play();
    }

    private void GameManagerOnLevelLoaded()
    {
        ChangeMusic(Registry.LastLevelIndex);
    }
}
