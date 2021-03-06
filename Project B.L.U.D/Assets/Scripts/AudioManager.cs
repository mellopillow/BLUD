﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource musicSource;

    public static AudioManager instance = null;
    public AudioClip[] music;
    public AudioClip[] sfx;
    public static int playCount = 0;

    void Awake()
    {
        if (playCount == 0)
        {
            Debug.Log("awake started");
            PlayMusic(music[1], .9f);
            
        }
    }

    void Start()
    {
        Debug.Log("Start");
        //Check for AudioManager
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        print(playCount);
        //Use if you don't want to destroy between scenes.
        DontDestroyOnLoad(this.gameObject);
        
       
    }

    public void Update()
    {
        if (playCount == 1)
        {

            PlayMusic(music[0], .9f);
            //playCount++;
        }
        
    }

    public void PlaySFXClip(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    //Note: AudioManager is set to only play one song at a time
    public void PlayMusic(AudioClip clip, float volume)
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }

    //Warning: This will stop ALL currently playing SFX
    public void StopSFX()
    {
        if (sfxSource.isPlaying)
            sfxSource.Stop();
    }

    //Sets the master music volume where volume is a float in the range (0, 1.0)
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    //Sets the master SFX volume where volume is a float in the range (0, 1.0)
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    //Selects and plays a random clip from a given selection
    public void randomSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        sfxSource.PlayOneShot(clips[randomIndex]);
    }

    public void randomMusic(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length - 1);
        PlayMusic(clips[randomIndex], .9f);
    }

}
