using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private SpriteRenderer _spriteRenderer;
    [SerializeField]private Sprite[] _sprites;
    private int _coinCount = 0;

    private PlayerAnimation _playerAnimation;

    public static event Action<int> OnShowCoin;
    public static event Action<bool,int> OnEnd;
    private void Start()
    {
        _playerAnimation = gameObject.AddComponent<PlayerAnimation>();
        OnShowCoin?.Invoke(_coinCount);
    }
    private void OnEnable()
    {
        ChekCell.OnAddCoin += addCoin;
        ChekCell.OnEnd += endGame;
        InputManager.OnMoveTo += ChangeRotation;
    }
    private void OnDisable()
    {
        ChekCell.OnAddCoin -= addCoin;
        ChekCell.OnEnd -= endGame;
        InputManager.OnMoveTo -= ChangeRotation;
    }
    private void addCoin()
    {
        _coinCount++;
        OnShowCoin?.Invoke(_coinCount);
    }
    private void endGame(bool win)
    {
        if(win)
        {
            SaveMeneger.AddToSave(new MainSave(_coinCount));
        }
        OnEnd?.Invoke(win,_coinCount);
    }
    private void ChangeRotation(Vector3 vector)
    {
        Vector3[] vectors= new Vector3[4] { Vector3.down,  Vector3.left ,Vector3.up , Vector3.right  };
        for(int i=0; i<vectors.Length; i++)
        {
          if (vector == vectors[i])
          {
                _playerAnimation.SetRotation(i);
             return;
          }
        }
    }
    
}
