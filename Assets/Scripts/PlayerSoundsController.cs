using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundsController : MonoBehaviour
{
    public AudioClip eatAudioClip;
    public AudioClip hurtAudioClip;
    public AudioClip shootAudioClip;
    private PlayerCharacter _player;
    private AudioSource _playerAudioSource; 
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        _playerAudioSource = _player.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        PlayerCharacter.PlayerEat += OnPlayerEatPlaySound;
        PlayerCharacter.PlayerHurt += OnPlayerHurtPlaySound;
        PlayerCharacter.PlayerShoot += OnPlayerShootPlaySound;
    }

    private void OnDisable()
    {
        PlayerCharacter.PlayerEat -= OnPlayerEatPlaySound;
        PlayerCharacter.PlayerHurt -= OnPlayerHurtPlaySound;
    }
    private void OnPlayerEatPlaySound() => _playerAudioSource.PlayOneShot(eatAudioClip);
    private void OnPlayerHurtPlaySound() => _playerAudioSource.PlayOneShot(hurtAudioClip);
    private  void OnPlayerShootPlaySound() => _playerAudioSource.PlayOneShot(shootAudioClip);
}
