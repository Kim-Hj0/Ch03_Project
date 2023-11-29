using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    //움직일 때, walk 애니메이션으로 전환
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
        //애니메이션 변경
        anim.SetBool("walk", dir.magnitude > 0f);
    }
}
