using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    
    public enum AudioTypes { sound, music}

    public AudioTypes audioTypes;

    public AudioClip clip;

    [Range(0,1)]
    public float volume;

    [Range(1,3)]
    public float pitch;

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
