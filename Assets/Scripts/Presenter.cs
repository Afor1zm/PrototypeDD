using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{    
    public void UnitMove(Unit _unit)
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Vector2 move = new Vector2(horizontal, 0);

            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                _unit.lookDirection.Set(move.x, move.y);
                _unit.lookDirection.Normalize();
            }

            Vector2 position = _unit.rigidbody2d.position;
            position = position + move * 50 * Time.deltaTime;
            _unit.rigidbody2d.MovePosition(position);
            UnitSetTriggerWalk(_unit);
        }
    }

    public void UnitGetRigidBody(Unit _unit)
    {
        _unit.rigidbody2d = _unit.GetComponent<Rigidbody2D>();
        _unit.animator = _unit.GetComponent<Animator>();
    }

    public void UnitSetTriggerWalk(Unit _unit)
    {
        _unit.animator.SetTrigger("Walk");
    }

    public void UnitSetTriggerAttack(Unit _unit)
    {
        _unit.animator.SetTrigger("Attack");
    }
    public void UnitSetTriggerHurt(Unit _unit)
    {
        _unit.animator.SetTrigger("Hurt");
    }
    public void UnitSetTriggerDie(Unit _unit)
    {
        _unit.animator.SetTrigger("Die");
    }
}
