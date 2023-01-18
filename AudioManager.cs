using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundMixerGroup;
    
    public Sound[] sounds;

    public static AudioManager instance; 
    void Awake()
    {
        if(instance==null)// new level adds new manager we want to retain old to avoid music break
        instance = this;
        else
        {
            Destroy(gameObject); //kill this one if another instance exists
            return; // avoid execution below
        }
        DontDestroyOnLoad(gameObject); //keep it running


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>(); //internal component needed to generate audio from clip
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            switch (s.audioType){
                case Sound.AudioTypes.soundEffect:
                s.source.outputAudioMixerGroup=soundMixerGroup;
                break;
                case Sound.AudioTypes.music:
                s.source.outputAudioMixerGroup=musicMixerGroup;
                break;
            }
        }
        this.Play("Music");
    }

    
    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name); // from array sounds, find  element (sound) with its propert name sound = to the passed function parameter name
       if(s==null)// avoid error for any misspelled sound
       {
        Debug.LogWarning("Sound: "+ name+" not found");
        return; 

       }  
       s.source.Play();
    }
        public void PlayDelayed(string name, float delay)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name); // from array sounds, find  element (sound) with its propert name sound = to the passed function parameter name
       if(s==null)// avoid error for any misspelled sound
       {
        Debug.LogWarning("Sound: "+ name+" not found");
        return; 

       }  
       s.source.PlayDelayed(delay);
    }

}

