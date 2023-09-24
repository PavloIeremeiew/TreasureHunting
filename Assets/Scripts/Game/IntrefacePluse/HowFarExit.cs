using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowFarExit: MonoBehaviour
{
    private Transform _playerPos;
    private Vector2 _exitPos;
    private float _step;
    private int _size;

    public static event Action<float> OnSetExitBarValue;

    public void Setter(Transform playerPos, Vector2 exitPos, float step, int size)
    {
        _playerPos = playerPos;
        _exitPos = exitPos;
        _step = step;
        _size = size;
    }

    private void OnEnable()
    {
        Move.OnCanMove += SetValue;
    }
    private void OnDisable()
    {
        Move.OnCanMove -= SetValue;
    }
    private void SetValue(bool can)
    {
        if (!can)
            return;
        float way = Math.Abs((int)((_playerPos.position.x - _exitPos.x) / _step)) + Math.Abs((int)((_playerPos.position.y - _exitPos.y) / _step));
        float maxWay = _size * 2;
        OnSetExitBarValue?.Invoke((maxWay-way)/ maxWay);

    }
}
