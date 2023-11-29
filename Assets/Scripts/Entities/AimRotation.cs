using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AimRotation : MonoBehaviour
{

    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //���⿡ ���� �к� ȸ��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 torchDirection = mousePosition - armPivot.position;
        float angle = Mathf.Atan2(torchDirection.y, torchDirection.x) * Mathf.Rad2Deg;

        //���⿡ ���� ������ ����
        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
