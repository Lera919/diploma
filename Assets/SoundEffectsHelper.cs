using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsHelper : MonoBehaviour
{

    // Синглтон
    public static SoundEffectsHelper Instance;

    public AudioClip playerEatSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    void Awake()
    {
        // регистрируем синглтон
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeEatSound(AudioSource source)
    {
        MakeSound(playerEatSound, source);
    }

    public void MakePlayerShotSound(AudioSource source)
    {
        MakeSound(playerShotSound, source);
    }

    public void MakeEnemyShotSound(AudioSource source)
    {
        MakeSound(enemyShotSound, source);
    }

    // Играть данный звук
    private void MakeSound(AudioClip originalClip, AudioSource source)
    {
        source.PlayOneShot(originalClip);
    }
}
