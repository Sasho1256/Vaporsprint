using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Dictionary<string, float> defaultVolumes = new Dictionary<string, float>();
    public static AudioManager instance;
    private bool isMuted = false;

    //saves the current instance to a variable, so that it doesn't need to be initialized every time its needed
    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //sets the defined variables from Sound.cs to the variables from the associated AudioSourcec
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            defaultVolumes.Add(s.name, s.volume);
        }
    }

    //finds the sound with the name "name" in the Array and plays the associated AudioSource
    public void Play(string name) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null) {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
    }
        s.source.Play();
    }

    //returns the associated AudioSource from the sound with the name "sound"
    public AudioSource getAudioSource(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return null;
        }
        return s.source;
    }

    //stops playing the sound with the name "sound"
    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    //stops all sounds in the Array
    public void StopAll()
    {
        foreach(Sound s in sounds)
        {
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.Stop();
        }
    }

    //depending on whether the sound is currently muted or not it unmutes/mutes it
    public void MuteOrUnmute()
    {
        if (!isMuted)
        {
            foreach (Sound s in sounds)
            {
                s.source.volume = 0f;
            }
            isMuted = true;
            return;
        } 
        foreach (Sound s in sounds)
        {
            if (defaultVolumes.ContainsKey(s.name))
            {
                s.source.volume = defaultVolumes[s.name];
            }
            else
            {
                Debug.LogWarning("Sound not found");
            }
            isMuted = false;
        }
    }
}
