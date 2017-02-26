using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{
    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public Transform[] wayPoints;
    public int direction = 0;
    public Transform camp;
    public GameObject flag;
    public GameObject FOVFlag;
    public Color FOVWhite;
    public Color FOVYellow;
    public Color FOVRed;

    public float waitO;
    public float waitD;
    public float waitB;
    public float waitL;

    [HideInInspector]
    public float angleofview;
    [HideInInspector]
    public Transform bullied;
    [HideInInspector]
    public Transform distraction;
    [HideInInspector]
    public float curTime;
    [HideInInspector]   
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public OrderState orderState;
    [HideInInspector]
    public OWaiterState owaiterState;
    [HideInInspector]
    public DistractState distractState;
    [HideInInspector]
    public DWaiterState dwaiterState;
    [HideInInspector]
    public BlamerState blamerState;
    [HideInInspector]
    public VictimeState victimeState;
    [HideInInspector]
    public LarsenState larsenState;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Awake()
    {
        chaseState = new ChaseState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);
        orderState = new OrderState(this);
        owaiterState = new OWaiterState(this);
        distractState = new DistractState(this);
        dwaiterState = new DWaiterState(this);
        blamerState = new BlamerState(this);
        victimeState = new VictimeState(this);
        larsenState = new LarsenState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start()
    {
        currentState = patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
