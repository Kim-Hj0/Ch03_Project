using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // event 외부에서 호출하지 못하게 막는다.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    //이런 걸 만들었을 때는 나만 쓸 수 있도록 만드는 게 좋다.(플레이어)
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected bool IsAttacking { get; set; }    //어택에 대한 프로퍼티

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= 0.1f)   //TODO
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        if (IsAttacking && _timeSinceLastAttack > 0.1f)
        {
            _timeSinceLastAttack = 0;   //0으로 초기화해줘야함.
            CallAttackEvent();  //공격을 시전한다.
        }
    }



    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);// ?. null이 아닐 때만 동작하게 만들어줌.
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}