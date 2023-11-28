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
        _controller = GetComponent<CharacterController>(); // 상위에 있는 TopDownCharacterController 가져오게 만드는 것.
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);   //키보드로 입력한 값을 _movementDirection로.
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    //이동 처리
    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 5;

        _rigidbody.velocity = direction;
    }
 }
