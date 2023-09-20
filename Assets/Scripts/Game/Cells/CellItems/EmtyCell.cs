using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmtyCell : ICellItem
{
    private TextMesh _text;
    private SpriteRenderer _renderer;
    private Sprite _coin;
    public EmtyCell(TextMesh text, SpriteRenderer renderer, Sprite sprite)
    {
        _text=text;
        _renderer=renderer;
        _coin=sprite;
    }

    public void Open(int bombCount, bool isCoinHere)
    {
        if (bombCount > 0)
            _text.text = bombCount.ToString();
        if (isCoinHere)
            _renderer.sprite = _coin;
    }
}
