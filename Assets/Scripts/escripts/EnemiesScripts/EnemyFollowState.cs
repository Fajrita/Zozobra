using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class EnemyFollowState : EnemyBaseState
{
    Vector3 lastPlayerPos;
    public override void EnterState(EnemyStateManager enemy)
    {
        
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.GetComponent<Animator>().SetFloat("Speed", enemy.followSpeed);
        Debug.Log("in follow");
        RaycastHit2D lookAt = Physics2D.Raycast(enemy.transform.position, new Vector2(enemy.transform.localScale.x, 0), enemy.visionRange, enemy.playerLayer);
        RaycastHit2D stickZone = Physics2D.CircleCast(enemy.transform.position, 2, Vector2.right, 0, enemy.playerLayer);
        RaycastHit2D lookZone = Physics2D.BoxCast(enemy.transform.position, enemy.boxRange, 0, Vector2.zero, enemy.playerLayer);

        if (stickZone.collider == enemy.Player.GetComponent<Collider2D>())
        {
           // enemy.SwitchState(enemy.stickState);
        }

        if (lookAt || lookZone)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,
            new Vector3(enemy.Player.transform.position.x, enemy.transform.position.y, enemy.transform.position.z), enemy.followSpeed * Time.deltaTime);
        }
        else { enemy.SwitchState(enemy.patrolState); }


    }
    public override void OnCollisionEnter(EnemyStateManager enemy, Collider2D collision)
    {
        //GameObject other = collision.gameObject;
        //if (other.CompareTag("Player"))
        //{
        //    enemy.SwitchState(enemy.stickState);
        //}
    }
}
