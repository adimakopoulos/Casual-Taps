using UnityEditor;
/// <summary>
/// This class is created for gameplay testing
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
}
