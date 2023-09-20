using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private GameObject _player;
    private ChekCell _chek;
    private Dictionary<Vector2, Cell> _cells = new Dictionary<Vector2, Cell>();
    public Dictionary<Vector2, Cell> Cells { private get { return _cells; } set { _cells = value; } }

    public static event Action<bool> OnCanMove;
    public void Start()
    {
        _player = this.gameObject;
        _chek = gameObject.AddComponent<ChekCell>();
        beforMove(_player.transform.position);
    }
    public void OnEnable()
    {
        InputManager.OnMoveTo += move;
    }
    public void OnDisable()
    {
        InputManager.OnMoveTo -= move;
    }
    private void beforMove(Vector3 position)
    {
        _chek.Ckek(_cells[position]);
        OnCanMove?.Invoke(true);
    }

    public void move(Vector3 vect)
    {
        Vector3 position = (vect * Constants.STEP) + _player.transform.position;
        try//я міг використати if (!_cells.ContainsKey(position)) return; але використав try catch  для прикладу           
        {
            _cells[position].Open();
            OnCanMove?.Invoke(false);

            StartCoroutine(moving(position));
        }
        catch (Exception)
        {
            return;
        }

    }
    private IEnumerator moving(Vector3 position)
    {
        while (_player.transform.position != position)
        {
            yield return new WaitForSeconds(1 / 60);
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, position, Constants.MOVE_SPEED * Time.deltaTime);
        }
        beforMove(position);
    }
}
