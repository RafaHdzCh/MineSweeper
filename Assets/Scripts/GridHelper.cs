using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static int w = 16;
    public static int h = 16;
    public static Cell[,] cells = new Cell[w,h];

    public static void UncoverAllTheMines()
    {
        foreach(Cell c in cells)
        {
            if(c.hasMine)
            {
                c.loadTexture(9);
            }
        }
    }

    public static bool HasMineAt(int x, int y)
    {
        if(x>=0 && y>=0 && x < w && y < h)
        {
            Cell cell = cells[x, y];
            return cell.hasMine;
        }
        else
        {
            return false;
        }
    }

    public static int CountAdjacentMines(int x, int y)
    {
        int count = 0;
        if (HasMineAt(x - 1, y - 1)) count++;   //Abajo-izquierda
        if (HasMineAt(x - 1, y    )) count++;   //Abajo-centro
        if (HasMineAt(x - 1, y + 1)) count++;   //Abajo-derecha
        if (HasMineAt(x    , y - 1)) count++;   //Medio-izquierda
        if (HasMineAt(x    , y + 1)) count++;   //Medio-derecha
        if (HasMineAt(x + 1, y - 1)) count++;   //Arriba-izquierda
        if (HasMineAt(x + 1, y    )) count++;   //Arriba-centro
        if (HasMineAt(x + 1, y + 1)) count++;   //Arriba-derecha

        return count;
    }

    public static void FloodFillUncover(int x, int y, bool[,] visited)
    {
        if(x>=0 && y>=0 && x<w && y<h)
        {
            if (visited[x, y]) return;

            int adjacentMines = CountAdjacentMines(x, y);
            cells[x, y].loadTexture(adjacentMines);

            if (adjacentMines > 0) return;

            visited[x, y] = true;
            FloodFillUncover(x - 1, y, visited); //Izquierda
            FloodFillUncover(x + 1, y, visited); //Derecha
            FloodFillUncover(x, y - 1, visited); //Abajo
            FloodFillUncover(x, y + 1, visited); //Arriba

            FloodFillUncover(x - 1, y - 1, visited);
            FloodFillUncover(x - 1, y + 1, visited);
            FloodFillUncover(x + 1, y - 1, visited);
            FloodFillUncover(x + 1, y + 1, visited); 
        }
    }

    public static bool HasTheGameEnded()
    {
        foreach(Cell cell in cells)
        {
            if(cell.IsCovered() && !cell.hasMine) return false;
        }

        return true;
    }


}
