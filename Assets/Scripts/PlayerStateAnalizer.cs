using System;
using UnityEngine;

public class PlayerStateAnalizer : MonoBehaviour
{
    public static event Action GameOver;
    public static event Action PlayerWin;
    public static event Action PlayerRunOutOfAttempts;

    [SerializeField] private int _maxScore;
    private PlayerCharacter _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        PlayerCharacter.PlayerEat += CheckPlayerProgress;
        PlayerCharacter.PlayerHurt += CheckPlayerHealth;
        PlayerCharacter.PlayerShoot += CheckPlayerAttempts;
    }

    private void CheckPlayerProgress()
    {
        if (_player.Score == _maxScore)
        {
            PlayerWin?.Invoke();
        }
    }

    private void CheckPlayerAttempts()
    {
        if(_player.Attempts == _player.PlayerConfiguration.MaxAttempts)
        {
            PlayerRunOutOfAttempts?.Invoke();
        }
    }
    private void CheckPlayerHealth()
    {
        if (_player.Health <= 0)
        {
            GameOver?.Invoke();
        }
    }
}
