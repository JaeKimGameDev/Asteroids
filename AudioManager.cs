using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundArray;

    public static AudioManager instance;

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in soundArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        Play("MainMenuTheme");
        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(soundArray, sound => sound.name == name);
        if (s == null)
        {
            //Debug.LogWarning("Sound: " + name + " not Found!");
            return;
        }
            
        s.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
