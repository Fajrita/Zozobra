using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStickState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy) {
        Debug.Log("stick");
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        enemy.transform.parent = enemy.Player.transform;
        enemy.transform.localPosition = Vector2.zero;
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        

    }
    public override void OnCollisionEnter(EnemyStateManager enemy, Collider2D collision) { }
}
