using Assets.Scripts;
using System;
using UnityEngine;

public abstract class PlayerCharacter: MonoBehaviour
{
    public static event Action PlayerShoot;
    public static event Action PlayerEat;
    public static event Action PlayerHurt;
    public static event Action IncreaseHealth;

    // public bool CanTeleport { get; set; } = false;
    public IConf PlayerConfiguration 
    {
        get => _playerConfiguration; 
        protected set => _playerConfiguration = value; 
    }

    public int Attempts { get => _attempts; protected set => _attempts = value; }
    public int Health { get; protected set; }
    public int Score { get; protected set; }

    [SerializeField] private int _attempts;
    [SerializeField]private IConf _playerConfiguration;

    //[SerializeField] private PortalCreator portalCreator;
    //public Vector3 PositionToTeleportat;

    private PauseController PauseController;
    protected Gun Gun;

    void Start()
    {
        Health = _playerConfiguration.MaxHealth;
        _attempts = _playerConfiguration.MaxAttempts;
        Gun = GameObject.FindGameObjectWithTag("Gun").
            GetComponent<Gun>();
        PauseController = GameObject.FindGameObjectWithTag("PauseController").
            GetComponent<PauseController>();
    }


    //public void CreateTeleport() => PositionToTeleportat = portalCreator.CreateTeleport(this.transform.position);
    //public void Teleport()
    //{
    //    if (this.CanTeleport)
    //    {
    //        this.transform.position = PositionToTeleportat;
    //    }
    //}
    public void HurtHandler(int damage) => OnPlayerHurt(damage);

    public void ShootHandler() => OnPlayerShoot();

    public void EatHandler() => OnPlayerEat();

    public void IncreaseHealthHandler(int save)
    {
        Health += save;
        Debug.Log("Health: " + Health);
    }
    public void Update()
    {
        if (PauseController.isPaused)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootHandler();
        }

        //if (Input.GetKeyDown(KeyCode.V) && this.CanTeleport)
        //{
        //    Debug.Log("input teleport");
        //    //CreateTeleport();
        //}
    }
    protected virtual void OnPlayerHurt(int damage)
    {
        PlayerHurt?.Invoke();
        Debug.Log("Health: " + Health);
    }
    protected virtual void OnPlayerEat()
    {
        Score++;
        PlayerEat?.Invoke();
        Debug.Log("Progress: " + Score);
    }

    protected virtual void OnPlayerShoot()
    {
        PlayerShoot?.Invoke();
        Debug.Log("You shoot!");
    }
}