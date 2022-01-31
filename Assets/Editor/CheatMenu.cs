using UnityEditor;
using UnityEngine;

/// <summary>
/// This class is only for gameplay testing
/// </summary>

public static class CheatMenu 
{

    [MenuItem("Cheats/Set Tile Hp to 1")]
    public static void SetTileHpTo1() {
        foreach (var item in TileStack.StackOTiles)
        {
            item.Health = 1;
        }


    }

    [MenuItem("Cheats/Delete Progress")]
    public static void DeleteProgress()
    {
        JsonManager.DeleteProgress();

    }


    [MenuItem("Cheats/Get 100 Coal")]
    public static void Add100Coal()
    {
        
        var StockPileCoal = GameObject.Find("StockPileCoal");
        if (StockPileCoal != null)
        {
            StockPileCoal.GetComponent<RainFallEffect>().getPiece(100);
        }
        else
        {
            Debug.Log("Cound Find StockPile.");
        }

    }

    [MenuItem("Cheats/Get 100 gold")]
    public static void add100Gold()
    {
        var StockPileGold = GameObject.Find("StockPileGold");
        if (StockPileGold != null)
        {
            StockPileGold.GetComponent<RainFallEffect>().getPiece(100);
        }
        else
        {
            Debug.Log("Cound Find StockPile.");
        }

    }

    [MenuItem("Cheats/Get 100 Iron")]
    public static void Add100Iron()
    {
        var StockPileIron = GameObject.Find("StockPileIron");
        if (StockPileIron != null)
        {
            StockPileIron.GetComponent<RainFallEffect>().getPiece(100);
        }
        else {
            Debug.Log("Cound Find StockPile.");
        }

    }
    [MenuItem("Cheats/Get 1.000 Iron")]
    public static void Add10000Iron()
    {
        var StockPileIron = GameObject.Find("StockPileIron");
        if (StockPileIron != null)
        {
            StockPileIron.GetComponent<RainFallEffect>().getPiece(1000);
        }
        else
        {
            Debug.Log("Cound Find StockPile.");
        }

    }

    [MenuItem("Cheats/Get 10 Coal in ElevatorB")]
    public static void Add10CoalToElevatorB()
    {
        var StockPileIron = GameObject.Find("ElevatorB");
        if (StockPileIron != null)
        {
            StockPileIron.GetComponent<ElevatorManager>().AddPiece(TileManager.TypeMetal.coal , 10);
                
        }
        else
        {
            Debug.Log("Cound Find StockPile.");
        }

    }
}
