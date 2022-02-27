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


    [MenuItem("Cheats/Add Recource/Get 100 Coal")]
    public static void Add100Coal()
    {
        
        var StockPileCoal = GameObject.Find("StockPileCoal");
        if (StockPileCoal != null)
        {
            for (int i = 0; i < 100; i++)
            {
                StockPileCoal.GetComponent<InventoryManager>().Add1SmallPiece(TileManager.TypeMetal.coal);
            }
            
        }
        else
        {
            Debug.Log("Cound Find StockPile.");
        }

    }

    [MenuItem("Cheats/Add Recource/Get 100 gold")]
    public static void add100Gold()
    {
        var StockPileGold = GameObject.Find("StockPileCoal");
        if (StockPileGold != null)
        {
            for (int i = 0; i < 100; i++)
            
                StockPileGold.GetComponent<InventoryManager>().Add1SmallPiece(TileManager.TypeMetal.gold);
        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }

    [MenuItem("Cheats/Add Recource/Get 100 Iron")]
    public static void Add100Iron()
    {
        var StockPileIron = GameObject.Find("StockPileCoal");
        if (StockPileIron != null)
        {
            for (int i = 0; i < 100; i++)
                StockPileIron.GetComponent<InventoryManager>().Add1SmallPiece(TileManager.TypeMetal.iron);
        }
        else {
            Debug.Log("Coundn't Find StockPile.");
        }

    }
    [MenuItem("Cheats/Add Recource/Get 1.000 Iron")]
    public static void Add10000Iron()
    {
        var StockPileIron = GameObject.Find("StockPileIron");
        if (StockPileIron != null)
        {
            StockPileIron.GetComponent<RainFallEffect>().AddSmallPieces(1000);
        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }

    [MenuItem("Cheats/Add Recource/Get 10 Coal in ElevatorB")]
    public static void Add10CoalToElevatorB()
    {
        var StockPileElevatorB = GameObject.Find("ElevatorB");
        if (StockPileElevatorB != null)
        {
            StockPileElevatorB.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.coal);
                
        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }

    [MenuItem("Cheats/Add Recource/Get 10 Coal in ElevatorA")]
    public static void Add10CoalToElevatorA()
    {
        var StockPileElevatorA = GameObject.Find("ElevatorA");
        if (StockPileElevatorA != null)
        {
            StockPileElevatorA.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.coal);

        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }
    [MenuItem("Cheats/Add Recource/Get 50 Coal in MinerStockPile")]
    public static void Add10CoalToMinerStockPile()
    {
        var MinerStockPile = GameObject.Find("MinerStockPile");
        if (MinerStockPile != null)
        {
            MinerStockPile.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.coal);

        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }
    [MenuItem("Cheats/Add Recource/Get 1 Coal,1 Gold, 1 Iron in MinerStockPile")]
    public static void Add1OfEachToMinerStockPile()
    {
        var MinerStockPile = GameObject.Find("MinerStockPile");
        if (MinerStockPile != null)
        {
            MinerStockPile.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.coal);
            MinerStockPile.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.iron);
            MinerStockPile.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.gold);
        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }
    [MenuItem("Cheats/Add Recource/Get 1 Coal,1 Gold, 1 Iron in ElevatorLoader")]
    public static void Add1OfEachToElevatorLoader()
    {
        var ElevatorLoader = GameObject.Find("ElevatorLoader");
        if (ElevatorLoader != null)
        {
            ElevatorLoader.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.coal);
            ElevatorLoader.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.iron);
            ElevatorLoader.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.gold);
        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }

    [MenuItem("Cheats/Add Recource/Get 22 Iron in MinerStockPile")]
    public static void Add22IronToMinerStockPile()
    {
        var MinerStockPile = GameObject.Find("MinerStockPile");
        if (MinerStockPile != null)
        {
            for (int i = 0; i < 22; i++)
            {
                MinerStockPile.GetComponent<StockPileManager>().Add1SmallPiece(TileManager.TypeMetal.iron);
            }
            

        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }

    [MenuItem("Cheats/Remove Recource/Remove 11 Coal in MinerStockPile")]
    public static void Withdraw10CoalToMinerStockPile()
    {
        var MinerStockPile = GameObject.Find("MinerStockPile");
        if (MinerStockPile != null)
        {

            MinerStockPile.GetComponent<StockPileManager>().RemovePiece(TileManager.TypeMetal.coal, 11);
        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }
    [MenuItem("Cheats/Remove Recource/Remove 11 Coal,11 gold,11 Iron in StockPileCoal")]
    public static void Remove11StockPileCoal()
    {

        var StockPileCoal = GameObject.Find("StockPileCoal");
        if (StockPileCoal != null)
        {

            StockPileCoal.GetComponent<InventoryManager>().RemovePiece(TileManager.TypeMetal.coal, 11);
            StockPileCoal.GetComponent<InventoryManager>().RemovePiece(TileManager.TypeMetal.iron, 11);
            StockPileCoal.GetComponent<InventoryManager>().RemovePiece(TileManager.TypeMetal.gold, 11);
        }
        else
        {
            Debug.Log("Coundn't Find StockPile.");
        }

    }

    [MenuItem("Cheats/Add Worker to TransportPeopleB")]
    public static void AddWorkerTransportPeopleB()
    {
        var StockPileElevatorA1 = GameObject.Find("TransportPeopleB");
        if (StockPileElevatorA1 != null)
        {
            StockPileElevatorA1.GetComponent<PeopleManager>().IncreaceWorker();

        }
        else
        {
            Debug.Log("Coundn't Find TransportPeopleB.");
        }

    }
   
    [MenuItem("Cheats/Add Worker to TransportPeopleC")]
    public static void AddWorkerTransportPeopleC()
    {
        var StockPileElevatorA1 = GameObject.Find("TransportPeopleC");
        if (StockPileElevatorA1 != null)
        {
            StockPileElevatorA1.GetComponent<PeopleManager>().IncreaceWorker();

        }
        else
        {
            Debug.Log("Coundn't Find TransportPeopleB.");
        }

    }


    [MenuItem("Cheats/Give Stats To Worker/Double Speed")]
    public static void DoubleSpeedTransportPeopleB()
    {
        var TransportPeopleB = GameObject.Find("TransportPeopleB");
        if (TransportPeopleB != null)
        {
            var workerManagerScript = TransportPeopleB.GetComponent<PeopleManager>();
            workerManagerScript.PeopleData.speedNormal *= 2f;
            workerManagerScript.PeopleData.speedCarrying *= 2f;
            workerManagerScript.UpdateWorkerStats_Speed();

        }
        else
        {
            Debug.Log("Coundn't Find TransportPeopleB.");
        }

    }
}
