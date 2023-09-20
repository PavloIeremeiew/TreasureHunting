using UnityEngine;

public class ExitCell : ICellItem
{
    private SpriteRenderer _renderer;
    private Sprite _sprite;
    public ExitCell(SpriteRenderer renderer, Sprite sprite)
    {
        _renderer = renderer;
        _sprite = sprite;
    }

    public void Open(int bombCount, bool isCoinHere)
    {
        _renderer.sprite = _sprite;
    }

}
