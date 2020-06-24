using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{    
    public void PlayerMove(Unit unit)
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Vector2 move = new Vector2(horizontal, 0);

            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                unit.lookDirection.Set(move.x, move.y);
                unit.lookDirection.Normalize();
            }

            Vector2 position = unit.rigidbody2d.position;
            position = position + move * 50 * Time.deltaTime;
            unit.rigidbody2d.MovePosition(position);
            UnitSetTriggerWalk(unit);
        }
    }

    public void UnitMove (Unit unit)
    {
        Transform startPoint;
        //startPoint = transform.position(unit);
        Vector2 position = unit.rigidbody2d.position;
        Vector2 move = new Vector2(position.x +50, 0);
        //position = position + move  * 50 * Time.deltaTime;
        unit.rigidbody2d.MovePosition(position);
        UnitSetTriggerWalk(unit);
        transform.position = Vector2.Lerp(transform.position, move, 1f * Time.deltaTime);
        //transform.position = Vector2.ler
    }

    public void UnitGetRigidBody(Unit unit)
    {
        unit.rigidbody2d = unit.GetComponent<Rigidbody2D>();
        unit.animator = unit.GetComponent<Animator>();
        unit.SpriteRenderer = unit.GetComponent<SpriteRenderer>();
    }

    public void UnitSetTriggerWalk(Unit unit)
    {
        unit.animator.SetTrigger("Walk");
    }

    public void UnitSetTriggerAttack(Unit unit)
    {
        unit.animator.SetTrigger("Attack");
    }
    public void UnitSetTriggerHurt(Unit unit)
    {
        unit.animator.SetTrigger("Hurt");
    }
    public void UnitSetTriggerDie(Unit unit)
    {
        unit.animator.SetTrigger("Die");
    }

    public void UnitSetTarget(Unit unit)
    {
        unit.SpriteRenderer.material.SetColor("_Color", Color.red);        
    }
    public void UnitSetUntarget(Unit unit)
    {
        unit.SpriteRenderer.material.SetColor("_Color", Color.white);
    }
}
