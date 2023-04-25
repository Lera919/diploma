using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] public Text scoreLabel;
    [SerializeField] public Image healthBar;
    [SerializeField] private Text Attempts;
    [SerializeField] private MessageController _messageController;


    private PlayerCharacter _player;
    private float _healthBarPercentage;

    private void Start()
    {
        _messageController = new MessageController();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        PlayerStateAnalizer.PlayerRunOutOfAttempts += RunOutOfAttempts;
    }
    private void OnEnable()
    {
        PlayerCharacter.PlayerEat += PlayerHealthChange;
        PlayerCharacter.PlayerHurt += PlayerHealthChange;
        PlayerCharacter.PlayerShoot += PlayerShoot;
        PlayerStateAnalizer.GameOver += GameOver;
    }

    private void OnDisable()
    {
        PlayerCharacter.PlayerEat -= PlayerHealthChange;
        PlayerCharacter.PlayerHurt -= PlayerHealthChange;
        PlayerCharacter.PlayerShoot -= PlayerShoot;
    }
    private void OnEnemyHit()
    {
        scoreLabel.text = "Score " + _player.Score;
    }

    private void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }
    private void PlayerHealthChange()
    {
        _healthBarPercentage = _player.Health / _player.MaxHealth;
        healthBar.fillAmount = _healthBarPercentage;
    }

    private void RunOutOfAttempts() => 
            StartCoroutine(_messageController.ShowMessage("you are run out off attempts!!!"));
    private void PlayerShoot()
    {
        Attempts.text = $"Attempts {_player.Attempts}/{PlayerStateAnalizer.MaxAttempts}";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}