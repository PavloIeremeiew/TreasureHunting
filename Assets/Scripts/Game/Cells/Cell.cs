using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private TextMesh _countText;
    [SerializeField] private Sprite _bombIcon, _exitIcon, _coinIcon, _closedCell, _openCell;
    [SerializeField] private SpriteRenderer _cellRenderer, _iconRenderer;
    private CellType _type = CellType.EmptyCell;
    private bool _isCoinHere = false;
    private int _bombBesideCount = 0;
    private bool _isCellOpen = false;
    private bool _isCellDone = false;
   [SerializeField] private ICellItem _cellItem;

    public CellType Type { 
        get => _type;
        set 
        {
            _type = value;
        }
    }
    public bool IsCoinHere { get => _isCoinHere; set => _isCoinHere = value; }
    public int BombBesideCount { get => _bombBesideCount; set => _bombBesideCount = value; }
    public bool IsCellOpen { get => _isCellOpen; private set => _isCellOpen = value; }
    public bool IsCellDone 
    { 
        get => _isCellDone; 
        set 
        { 
            _isCellDone = value;
            switch (_type)
            {
                case CellType.EmptyCell:
                    _cellItem = new EmtyCell(_countText, _iconRenderer, _coinIcon);
                    break;
                case CellType.ExitCell:

                    _cellItem = new ExitCell( _iconRenderer, _exitIcon);
                    break;
                case CellType.BombCell:

                    _cellItem = new BombCell( _iconRenderer, _bombIcon);
                    break;
            }
        } }

    public void Awake()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y * Constants.Z_POSITION_STEP);
    }
    

    public void Open()
    {
        _cellRenderer.sprite = _openCell;
        _isCellOpen = true;
        //switch (_type)
        //{
        //    case CellType.EmptyCell:
        //        if (_bombBesideCount > 0)
        //            _countText.text = _bombBesideCount.ToString();
        //        if (_isCoinHere)
        //            _iconRenderer.sprite = _coinIcon;
        //        break;
        //    case CellType.BombCell:
        //        _iconRenderer.sprite = _bombIcon;
        //        break;
        //    case CellType.ExitCell:
        //        _iconRenderer.sprite = _exitIcon;
        //        break;

        //}
        _cellItem.Open(_bombBesideCount, _isCoinHere);
    }
    public void HideIcon()
    {
        Texture2D emptyTexture = new Texture2D(1, 1);
        emptyTexture.SetPixel(0, 0, new Color(0, 0, 0, 0)); // „орний кол≥р з альфа-каналом 0 (прозор≥сть)
        emptyTexture.Apply();

        _iconRenderer.sprite = Sprite.Create(emptyTexture, new Rect(0, 0, 1, 1), Vector2.zero);
    }
}

public enum CellType
{
    EmptyCell,
    BombCell,
    ExitCell
}

