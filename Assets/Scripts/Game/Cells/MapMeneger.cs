using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMeneger : MonoBehaviour
{

    [SerializeField] private GameObject _cellPrefab, _player;
    private Dictionary<Vector2, Cell> _cells;
    private MapGenerator _generator;

    private void Awake()
    {
        _generator= gameObject.AddComponent<MapGenerator>();
        _cells = _generator.GeneraitMap(_cellPrefab, Constants.SIZE, Constants.STEP);
        _generator.GeneraitExit(_cells, Constants.STEP, Constants.EXIT_WAY_COUNT);
        _generator.SetSaveZone(_cells, Constants.STEP);
        _generator.SpawnBomb(_cells, Constants.SIZE, Constants.STEP, Constants.BOMB_COUNT);
        _generator.SetEmptyCell(_cells, Constants.STEP, Constants.COIN_COUNT);
        _generator.DoneAllCells(_cells);

    }
    private void Start()
    {
        _cells[Vector2.zero].Open();
        _player = Instantiate(_player);
        Move move= _player.AddComponent<Move>();
        move.Cells= _cells;
    }
}
