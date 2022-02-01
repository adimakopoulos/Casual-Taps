using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public List<Rigidbody> LoosePecies;
    public RainFallEffect []Spawners;//Is set in the inspector
    public static Action OnLoosePiecesProcessed;

    public int GoldOre, CoalOre, IronOre;
    private void Awake()
    {
        



        LoosePecies = new List<Rigidbody>();
    }



    private void OnEnable()
    {
        SimpleGameEvents.OnTileShutter += addOre;
        SimpleGameEvents.OnPlayerCurrentlyLookingAt += moveOreToStokpile;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnTileShutter -= addOre;
        SimpleGameEvents.OnPlayerCurrentlyLookingAt -= moveOreToStokpile;

    }

    private void Update()
    {


    }
    private void moveOreToStokpile(int lookIndex) {
        //If players looks at StockPile Do:
        if (lookIndex == 0) {


            foreach (var item in LoosePecies)
            {


                var materialName  = item.GetComponent<Renderer>().material.name;

                if (materialName.Contains("Coal")) {
                    CoalOre ++;
                    Spawners[0].getPiece();
                }
                if (materialName.Contains("Gold"))
                {
                    GoldOre++;
                    Spawners[1].getPiece();
                }
                if (materialName.Contains("Iron"))
                {
                    IronOre++;
                    Spawners[2].getPiece();
                }

                
            }

            foreach (var item in LoosePecies)
            {
                Destroy(item.gameObject);
            }
            LoosePecies.Clear();
            OnLoosePiecesProcessed?.Invoke();

        }
        
    }

    /// <summary>
    /// every time a tile breaks all the smaller pieces get added to this list.
    /// </summary>
    /// <param name="brokenTile"></param>
    private void addOre(TileBrokenManager brokenTile) {
        //brokenTile.BrokenPieces[].MovePosition;

        foreach (var item in brokenTile.BrokenPieces)
        {
            LoosePecies.Add(item);
        }
    }
}
