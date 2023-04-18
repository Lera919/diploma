using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    //[SerializeField] private AudioSource soundSource;
    [SerializeField]
    private PortalCreator portalCreator;
    [SerializeField] private Text ScoreLabel;  
    [SerializeField] private float maxHealth;
    [SerializeField] private int MaxScore = 20;
    [SerializeField] private Image bar;


    private float fillBar;
    private int _health;

    private Vector3 positionToTeleportat;
    public bool CanTeleport { get; set; } = false;

    void Start()
    {
        portalCreator = GetComponent<PortalCreator>();
        ScoreLabel.text = "Score " + this.Score + $"/{MaxScore}";
        _health = (int)maxHealth;
        fillBar = _health/ maxHealth;
    }

    public int Score { get; private set; } = 0;

    public void CreateTeleport() => positionToTeleportat = portalCreator.CreateTeleport(this.transform.position);
    public void Teleport()
    {
        if (this.CanTeleport)
        {
            this.transform.position = positionToTeleportat;
        }
    }
    public void Hurt(int damage)
    {
        _health -= damage;
        fillBar = _health / maxHealth;
        Debug.Log("Health: " + _health);
      
    }

    public void Eat()
    {
        //soundSource.PlayOneShot();
        SoundEffectsHelper.Instance.MakeEatSound(this.GetComponent<AudioSource>());
        Score++;
        ScoreLabel.text = "Score " + this.Score + $"/{MaxScore}";
        if(this.Score == MaxScore)
        {
            GameStateAnalizer.Win();
        }
    }
    public void Plus(int save)
    {
        _health += save;
        fillBar = _health / maxHealth;
        Debug.Log("Health: " + _health);
    } 
    public void Update()
    {
        bar.fillAmount = fillBar;
        Debug.Log("Health: " + _health);
        if(_health <= 0)
        {
            GameStateAnalizer.GameOver();
        }

        if (Input.GetKeyDown(KeyCode.V) && this.CanTeleport)
        {
            Debug.Log("input teleport");
            CreateTeleport();
        }
    }
}