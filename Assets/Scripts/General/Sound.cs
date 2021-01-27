using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    #region Fields
    [SerializeField]
    string name;

    [SerializeField]
    AudioClip clip;

    [SerializeField]
    [Range(0f, 1f)]
    float volume;

    [SerializeField]
    [Range(.1f, 3)]
    float pitch;

    [SerializeField]
    bool loop;

    AudioSource source;
    #endregion

    #region Properties

    public string Name
    {
        get { return name; }
    }

    public AudioClip Clip
    {
        get { return clip; }
    }

    public float Volume
    {
        get { return volume; }
    }

    public float Pitch
    {
        get { return pitch; }
    }

    public bool Loop
    {
        get { return loop; }
    }

    public AudioSource Source
    {
        get { return source; }
        set { source = value; }
    }
    #endregion

}
