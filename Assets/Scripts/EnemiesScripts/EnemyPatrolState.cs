using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyPatrolState : EnemyBaseState
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private Vector3[] positions;

    private int index;


    public override void EnterState(EnemyStateManager enemy)
    {

    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        Debug.Log("in patrol");
        enemy.GetComponent<Animator>().SetFloat("Speed", enemy.speed);

        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.positions[index], enemy.speed * Time.deltaTime);

        RaycastHit2D lookAt = Physics2D.Raycast(enemy.transform.position, new Vector2(enemy.transform.localScale.x, 0), enemy.visionRange, enemy.playerLayer);
        RaycastHit2D stickZone = Physics2D.CircleCast(enemy.transform.position, 2, Vector2.right, 0, enemy.playerLayer);
        RaycastHit2D lookZone = Physics2D.BoxCast(enemy.transform.position, enemy.boxRange, 0, Vector2.zero, enemy.playerLayer);

        

        if (enemy.transform.position == enemy.positions[index])
        {


            if (index == enemy.positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }

        if (lookAt.collider == enemy.Player || lookZone.collider == enemy.Player)
        {
            
            //Debug.Log("found" + enemy.Player.transform.position);

           enemy.SwitchState(enemy.followState);


        }
        if (stickZone)
        {
            //enemy.SwitchState(enemy.stickState);
        }



    }
    public override void OnCollisionEnter(EnemyStateManager enemy, Collider2D collision)
    {

    }
}
