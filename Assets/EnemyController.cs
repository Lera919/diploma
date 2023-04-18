using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent navMeshAgent;

    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform[] points;
    private int destPoint = 0;
    private bool waitForAttack = false;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    public bool Alive { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
        //player = FindObjectOfType<PlayerCharacter>();
        player = GameObject.FindGameObjectWithTag("Player");
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        var position = player.transform.position;
        fpsTargetDistance = Vector3.Distance(position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            LookAtPlayer(position);
            Debug.Log("Посмотри пожалуйста на игрока");
            navMeshAgent.destination = position;
        }
        if (fpsTargetDistance < attackDistance)
        {
            if (!waitForAttack)
            {
                StartCoroutine(attackPlease());
            }
            waitForAttack = true;
        }
        else
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            GameStateAnalizer.GameOver();
        }
    }
    void LookAtPlayer(Vector3 position)
    {
        Quaternion rotation = Quaternion.LookRotation(position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

    }

    IEnumerator attackPlease()
    {
        
        //transform.Translate(0, 0, enemyMovementSpeed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        //ray.direction += new Vector3(0, 2, 0);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
              
                if (_fireball == null)
                {  
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint((Vector3.forward + new Vector3(0, 0.5f, 0)) * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
        }
        yield return new WaitForSeconds(5f);
        waitForAttack = false;
        //yield return new WaitForSeconds(3f);
    }



    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        navMeshAgent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

}
