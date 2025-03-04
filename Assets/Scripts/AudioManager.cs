using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region SINGLETON
    public static AudioManager Singleton;


    private void Awake()
    {
        PlaySound("Victoria");

        if (Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }
    #endregion

    //[SerializeField] AudioClip[] soundEffects;
    [SerializeField] Sound[] sounds;

    private List<AudioSource> audioSources = new List<AudioSource>();



    public void PlaySound(string soundName)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.nomClip == soundName)
            {
                PlaySounds(sound.audioClip);
            }
        }
    }

    public void PlaySounds(AudioClip soundClip)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
                return;
            }
        }
        AudioSource source = CreateNewAudioSource();
        source.clip = soundClip;
        source.Play();
    }

    private AudioSource CreateNewAudioSource()
    {
        // Create a new object
        GameObject GO = new GameObject();
        GO.name = "AudioSource";
        GO.transform.parent = this.transform;

        // Ajoute un AUdioSource a l'objet
        AudioSource source = GO.AddComponent<AudioSource>();
        audioSources.Add(source);

        return source;
    }
}

[System.Serializable]
public struct Sound
{
    public AudioClip audioClip;
    public string nomClip;
}
