using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Move.OnCanMove += MoveAnim;
    }
    private void OnDisable()
    {
        Move.OnCanMove -= MoveAnim;
    }

    public void SetRotation(int rotation)
    {
        _animator.SetInteger("Rotation", rotation);
    }
    private void MoveAnim(bool move) => _animator.SetBool("IsWalking", !move);
}
