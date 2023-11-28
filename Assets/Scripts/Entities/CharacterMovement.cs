using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>(); // ������ �ִ� TopDownCharacterController �������� ����� ��.
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);   //Ű����� �Է��� ���� _movementDirection��.
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    //�̵� ó��
    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 5;

        _rigidbody.velocity = direction;
    }
 }
