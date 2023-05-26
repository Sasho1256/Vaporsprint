using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
    }

    // Update is called once per frame
    public void Play(string name) {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null) {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
    }
        s.source.Play();
    }

    public AudioSource getAudioSource(string name)
    {
        List<AudioSource> results = new List<AudioSource>();
        GetComponents<AudioSource>(results);

        foreach(Sound s in sounds)
        {
            if(s.name == name)
            {
                return s.source;
            }
        }
        return null;
    }

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
}
