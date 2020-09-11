
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    public Sound[] Sounds;
    void Awake()
    {
        foreach(Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;



        }
    }
    public void Play(string i_name)
    {
        Sound FoundSound = System.Array.Find(Sounds, i_sound => i_sound.name == i_name);
        AudioClip audioClip = FoundSound.source.clip;
        FoundSound.source.PlayOneShot(audioClip);







    }
}
