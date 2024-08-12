using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyFollowState followState = new EnemyFollowState();
    public EnemyPatrolState patrolState = new EnemyPatrolState();
    public EnemyStickState stickState = new EnemyStickState();
    public EnemyLightState lightState = new EnemyLightState();

    public Collider2D Player;
    public Vector3 initPos;

    public float speed;
    public float followSpeed;
    [SerializeField]
    public Vector3[] positions;
    public Vector2 boxRange;
    public int visionRange;
    public LayerMask playerLayer;
    public LayerMask sueloLayer;

    private float oldPos;

    


    private void Start()
    {
        Player = GameObject.Find("LookCollider").GetComponent<Collider2D>();

        initPos = transform.position;

        currentState = patrolState;
        oldPos = transform.position.x;

        currentState.EnterState(this);

    }

    private void Update()
    {
        if(transform.position.x >= oldPos && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
           
        }else if(transform.position.x < oldPos && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            
        }
        oldPos = transform.position.x;

        
        

        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            currentState.OnCollisionEnter(this, collision);
        }
    }

    public void LightReract()
    {
        SwitchState(lightState);
    }


    public void Wait(EnemyBaseState state)
    {
        StartCoroutine(WaitC(state));
    }

    IEnumerator WaitC(EnemyBaseState state)
    {
        
        yield return new WaitForSeconds(0.4f);
        SwitchState(state);
        
    }
  
}
