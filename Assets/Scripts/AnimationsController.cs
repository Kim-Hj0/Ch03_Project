using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    //������ ��, walk �ִϸ��̼����� ��ȯ
    PlayerInputController controller;

    [SerializeField] private Animator anim;
    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
      
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.OnMoveEvent += AnimState;
    }

    void AnimState(Vector2 dir)
    {
        //�ִϸ��̼� ����
        anim.SetBool("walk", dir.magnitude > 0f);
    }
}
