using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenerator : MonoBehaviour
{
    public Dictionary<Vector2, Cell> GeneraitMap(GameObject cellPrefab, int size, float step)
    {
        GameObject cellPerent = new GameObject("Cells");
        int middle = (size / 2) + 1;
        Dictionary<Vector2, Cell> cells = new Dictionary<Vector2, Cell>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(step * (j + 1 - middle), step * (i + 1 - middle), 0), Quaternion.identity, cellPerent.transform);
                cells[cell.transform.position] = cell.GetComponent<Cell>();
            }
        }

        return cells;
    }

    public Vector2 GeneraitExit(Dictionary<Vector2, Cell> cells, float step, int cellCount)
    {
        Vector2 position = new Vector2(0, 0), exitPos= Vector2.zero;
        cells[position].IsCellDone = true;

        int i = 0;
        while (i < cellCount)
        {
            Vector2 position1 = position + RundomVector() * step;
            if (cells.ContainsKey(position1) && !cells[position1].IsCellDone)
            {
                position = position1;

                if (i == cellCount - 1)
                {
                    cells[position].Type = CellType.ExitCell;
                    exitPos = position;
                }
                i++;
                cells[position].IsCellDone = true;
            }

        }
         
        return exitPos; 
    }
    public void SetSaveZone(Dictionary<Vector2, Cell> cells,  float step)
    {
        cells[Vector2.up*step].IsCellDone=true;
        cells[Vector2.right*step].IsCellDone=true;
        cells[Vector2.down*step].IsCellDone=true;
        cells[Vector2.left*step].IsCellDone=true;
    }
    private Vector2 RundomVector()
    {
        if (Random.Range(0, 2) == 1)
        {
            if (Random.Range(0, 2) == 1)
            {
                return new Vector2(1, 0);
            }
            else
            {
                return new Vector2(-1, 0);
            }
        }
        else
        {
            if (Random.Range(0, 2) == 1)
            {
                return new Vector2(0, 1);
            }
            else
            {
                return new Vector2(0, -1);
            }
        }
    }

    public void SpawnBomb(Dictionary<Vector2, Cell> cells, int size, float step, int bombCount)
    {
        int middle = (size / 2) + 1;
        int i = 0;
        while(i<bombCount)
        {
            Vector2 position = new Vector2(Random.Range(-middle + 1, middle) * step, Random.Range(-middle + 1, middle) * step);
            if (!cells[position].IsCellDone)
            {
                cells[position].Type = CellType.BombCell;
                i++;
            }
        }
    }

    public void SetEmptyCell(Dictionary<Vector2, Cell> cells, float step, int coinCount)
    {
        int currentCoinCount = 0;
        foreach (KeyValuePair<Vector2, Cell> cell in cells)
        {
            if (cell.Value.Type == CellType.EmptyCell)
            {
                if(currentCoinCount< coinCount&& cell.Key!=Vector2.zero && Random.Range(0, coinCount) ==0)
                {
                    cell.Value.IsCoinHere = true;
                    currentCoinCount++;
                }
                cell.Value.BombBesideCount = bombCount(cells, step, cell.Key);
             
            }
        }
    }
    public void DoneAllCells(Dictionary<Vector2, Cell> cells)
    {
        foreach(Cell cell in cells.Values)
        {
            if(!cell.IsCellDone)
                cell.IsCellDone = true;
        }
    }
    private int bombCount(Dictionary<Vector2, Cell> cells, float step,Vector2 cell) 
    {
        int count = 0;
        if(cells.ContainsKey(cell+(Vector2.up*step))&& cells[cell + (Vector2.up * step)].Type==CellType.BombCell)
            count++;
        if (cells.ContainsKey(cell + (Vector2.right * step)) && cells[cell + (Vector2.right * step)].Type == CellType.BombCell)
            count++;
        if (cells.ContainsKey(cell + (Vector2.down * step)) && cells[cell + (Vector2.down * step)].Type == CellType.BombCell)
            count++;
        if (cells.ContainsKey(cell + (Vector2.left * step)) && cells[cell + (Vector2.left * step)].Type == CellType.BombCell)
            count++;
        return count;

    }
    
}
