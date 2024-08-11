using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyLightState : EnemyBaseState
{

    private SpriteRenderer renderer;
    private Color lerpedColor;
    private Color maxTransp;
    private Color minTransp;
    public override void EnterState(EnemyStateManager enemy)
    {

        renderer = enemy.gameObject.GetComponent<SpriteRenderer>();
        maxTransp = new Color(1, 1, 1, 0.5f);
        minTransp = new Color(1, 1, 1, 0.8f);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        Debug.Log("inlight");
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.initPos, enemy.speed * Time.deltaTime);
        lerpedColor = Color.Lerp(maxTransp, minTransp, Mathf.PingPong(Time.time, 1));
        renderer.color = lerpedColor;

        if (enemy.transform.position == enemy.initPos)
        {

            renderer.color = new Color(1, 1, 1, 1);
            enemy.SwitchState(enemy.patrolState);

        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collider2D collision)
    {

    }
}
