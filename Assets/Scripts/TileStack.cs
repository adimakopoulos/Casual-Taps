using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStack : MonoBehaviour
{
    private static List<GameObject> stackOTiles;

    public static List<GameObject> StackOTiles { 
        
        get => stackOTiles;

        set { stackOTiles = value; 
        
        }
    }
}
