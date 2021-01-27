using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.Name == name);
        if (sound == null)
        {
            Debug.LogWarning($"{name} sound doesn't exist!");
            return;
        }
        sound.Source.PlayOneShot(sound.Source.clip);
    }
}
