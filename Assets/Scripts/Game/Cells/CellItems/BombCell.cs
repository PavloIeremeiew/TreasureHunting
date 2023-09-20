using UnityEngine;

public class BombCell : ICellItem
{
    private SpriteRenderer _renderer;
    private Sprite _sprite;
    public BombCell(SpriteRenderer renderer, Sprite sprite)
    {
        _renderer = renderer;
        _sprite = sprite;
    }

    public void Open(int bombCount, bool isCoinHere)
    {
        _renderer.sprite = _sprite;
    }
}
