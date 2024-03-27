using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UIElements;

//  Music track: Motivation for Success by Aylex
// Source: https://freetouse.com/music
// No Copyright Background Music

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // "Awake" can be used to instantiate sounds before the event happens
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        // Sound will not restart between scene transition
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    void Start()
    {
        Play("Main Menu");
        
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;

        }
        s.source.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
