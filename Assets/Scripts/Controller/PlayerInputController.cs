using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;  //���� �� ���� �����ϴ� ���� ī�޶� �������ڴ�.
    }

    public void OnMove(InputValue value)    //�� �տ� on�� ���̸� ������ �Ǿ��� �� �����޴� �Լ��� ����� ��.
    {
        Vector2 moveInput = value.Get<Vector2>().normalized; //.normalized; �ϴ� ����, �� ������ ���� ���������, �װ� �ƴ� ���.
        CallMoveEvent(moveInput);                           //.normalized ���� ������,���� ������ ������ �밢�� ������ �ſ� ����������.
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();  //���콺 �������� ������.
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);  //�װ� ���� ���������� �ٲ�.
        newAim = (worldPos = (Vector2)transform.position).normalized;   //�����׼� ���콺�� �ٶ󺸴� ����.

        if (newAim.magnitude >= .9f)    //magnitude�� ũ��
        {
            CallLookEvent(newAim);
        }
    }
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;  //������ Ű�� �Է��� �Ǹ�.
    }
}
