using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PeriodicPieceLoader : MonoBehaviour
{
    public GameObject UnloadHere, LoadHere, MyStockPile;
    IStockPile stockPileLoad, stockPileUnLoad, myStockPile;
    float rate = 1.0f;

    private void Awake()
    {
        stockPileLoad = LoadHere.GetComponent<IStockPile>();
        stockPileUnLoad = UnloadHere.GetComponent<IStockPile>();
        myStockPile = MyStockPile.GetComponent<IStockPile>();
        if (myStockPile == null)
        {
            Debug.Log("myStockPile == null");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadPiece", 2);
    }

    private void OnEnable()
    {
        myStockPile.GetInstance().GetComponentInChildren<ElevatorManager>().OnStateChanged += GetElevatorStage;
    }
    private void OnDisable()
    {
        myStockPile.GetInstance().GetComponentInChildren<ElevatorManager>().OnStateChanged -= GetElevatorStage;

    }
    ElevatorManager.State EStater;
    void GetElevatorStage(ElevatorManager.State a)
    {
        EStater = a;
        //Debug.Log("State" + EStater.ToString());

    }
    void LoadPiece()
    {
        if (EStater== ElevatorManager.State.GoingUp|| EStater == ElevatorManager.State.GoingDown) {
            Invoke("LoadPiece", rate);
            return;        
        }
        if (EStater == ElevatorManager.State.Loading)
        {
            var dic = stockPileLoad.RemoveLastPieces(1);
            if (dic!=null)
            {
                var type = dic.FirstOrDefault(x => x.Value == 1).Key;
                myStockPile.Add1SmallPiece(type);
            }

        }

        if (EStater == ElevatorManager.State.Unloading)
        {
            var dic = myStockPile.RemoveLastPieces(1);
            if (dic != null)
            {
                var type = dic.FirstOrDefault(x => x.Value == 1).Key;
                stockPileUnLoad.Add1SmallPiece(type);
            }
        }





        Invoke("LoadPiece", rate);
    }
}
