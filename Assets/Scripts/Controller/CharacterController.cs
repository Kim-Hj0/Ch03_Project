using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // event �ܺο��� ȣ������ ���ϰ� ���´�.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    //�̷� �� ������� ���� ���� �� �� �ֵ��� ����� �� ����.(�÷��̾�)
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected bool IsAttacking { get; set; }    //���ÿ� ���� ������Ƽ

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
            _timeSinceLastAttack = 0;   //0���� �ʱ�ȭ�������.
            CallAttackEvent();  //������ �����Ѵ�.
        }
    }



    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);// ?. null�� �ƴ� ���� �����ϰ� �������.
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