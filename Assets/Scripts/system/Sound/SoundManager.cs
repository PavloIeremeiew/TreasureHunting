using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundPlayer _player;
    [SerializeField] private AudioClip _coin,_die,_win,_move,_click;
    private void OnEnable()
    {
        ChekCell.OnAddCoin += coinSound;
        ChekCell.OnEnd += endSound;
        InputManager.OnMoveTo += moveSound;
        UIInputer.OnClick += clickSound;
    }
    private void OnDisable()
    {
        ChekCell.OnAddCoin -= coinSound;
        ChekCell.OnEnd -= endSound;
        InputManager.OnMoveTo -= moveSound;
        UIInputer.OnClick -= clickSound;
    }
    private void coinSound()
    {
        _player.PlaySound(_coin);
    }
    private void endSound(bool win)
    {
        if(win) 
        _player.PlaySound(_win);
        else
            _player.PlaySound(_die);
    }
    private void moveSound(Vector3 vec)
    {
        _player.PlaySound(_move);
    }
    private void clickSound()
    {
        _player.PlaySound(_click);
    }
}
