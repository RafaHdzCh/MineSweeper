using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Cell : MonoBehaviour
{
    private string cell = "cell";
    public bool hasMine;
    public Sprite[] emptySpriteTextures;
    public Sprite mineTexture;
    [SerializeField] SpriteRenderer cellSprite;
    [SerializeField] TextMeshProUGUI gameFinished;
    [SerializeField] GameObject victory;
    [SerializeField] Timer timer;


    private const float minePercentPerGame = 0.01f;

    void Start()
    {
        hasMine = Random.value < minePercentPerGame;
        int x = (int)this.transform.position.x;
        int y = (int)this.transform.parent.transform.position.y;
        GridHelper.cells[x, y] = this;
    }

    public void loadTexture(int adjacentCount)
    {
        if(hasMine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptySpriteTextures[adjacentCount];
        }
    }

    public bool IsCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == cell;
    }

    private void OnMouseUpAsButton()
    {
        if(hasMine)
        {
            GridHelper.UncoverAllTheMines();
            //Terminar la partida
            //Bloquear las celdas
        }
        else
        {
            int x = (int)this.transform.position.x;
            int y = (int)this.transform.parent.transform.position.y;
            loadTexture(GridHelper.CountAdjacentMines(x, y));
            GridHelper.FloodFillUncover(x, y, new bool[GridHelper.w, GridHelper.h]);
            if (GridHelper.HasTheGameEnded())
            {
                print("Fin de la partida");
                victory.SetActive(true);
                
            }
        }
    }


}