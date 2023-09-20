using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekCell : MonoBehaviour
{
    public static event Action<bool> OnEnd;
    public static event Action<int> OnShowBombNumber;
    public static event Action OnAddCoin;

    public void Ckek(Cell cell)
   {
        switch (cell.Type)
        {
            case CellType.BombCell:
                OnEnd?.Invoke(false);
            break;
            case CellType.ExitCell:
                OnEnd?.Invoke(true);
                break;
            case CellType.EmptyCell:
                OnShowBombNumber?.Invoke(cell.BombBesideCount);
                if(cell.IsCoinHere)
                {
                    cell.IsCoinHere = false;
                    cell.HideIcon();
                    OnAddCoin?.Invoke();
                }
                break;
        }
   }
}
