using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    public AudioMixer _mixer;

    public GameObject coinSFX; // object
    public GameObject heartSFX;
    public GameObject deathSFX;
    public GameObject checkpointSFX;

    private void Start()
    {
        UpdateMusicGroup(PlayerPrefs.GetFloat(Structs.Mixers.musicVolume)); // game loads will keep music
        UpdateSFXGroup(PlayerPrefs.GetFloat(Structs.Mixers.sfxVolume));
    }
    public void PlaySFX(string audioName)
    {
        StartCoroutine(CreateSFX(audioName)); // needed for the IEnumerator code to work
    }

    public IEnumerator CreateSFX(string audioName) // "IEnumerator" defines these codes as separate from the main
    {                                            // Vector   // Position 0 // rotation same as object pattern
        GameObject newAudio = Instantiate(GetSFX(audioName), Vector3.zero, Quaternion.identity); // creates a new copy of object
        newAudio.GetComponent<AudioSource>().Play(); // plays the new copy of object
        while (newAudio.GetComponent<AudioSource>().isPlaying) // "while" check if something is true; if true, will do that action
        {
            yield return null; // wait no seconds but keep checking
        }
        Destroy(newAudio); // destroys audio object after it's played
    }

    public GameObject GetSFX(string audioName)
    {
        switch (audioName)
        {
            case Structs.SoundEffects.coin:
                {
                    return coinSFX;
                }

            case Structs.SoundEffects.heart:
                {
                    return heartSFX;
                }

            case Structs.SoundEffects.death:
                {
                    return deathSFX;
                }

            case Structs.SoundEffects.checkpoint:
                {
                    return deathSFX;
                }
        }
        return null; // return nothing if nothing exist
    }

    public void UpdateSFXGroup(float newVolume)
    {
        _mixer.SetFloat(Structs.Mixers.sfxVolume, Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat(Structs.Mixers.sfxVolume, newVolume);
    }

    public void UpdateMusicGroup(float newVolume)
    {
        _mixer.SetFloat(Structs.Mixers.musicVolume, Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat(Structs.Mixers.musicVolume, newVolume); // prefs - save data like strings
    }
}



