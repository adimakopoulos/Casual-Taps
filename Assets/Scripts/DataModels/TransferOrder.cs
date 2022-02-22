using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Carry a quantity of objects from Supplier(Worldspace Coordinates) to Consumer(Worldspace Coordinates).
/// </summary>
public class TransferOrder
{
    
    public Vector3 Supplier;
    public Vector3 Consumer;
    public int Ammount;
    public enum TranferStage {GoingToSupplier, Withdrawing,GoingToConsumer , Depositing };
    public TranferStage CurrentStage;
    public TransferOrder(Vector3 supplier, Vector3 consumer, int CarryAmmount)
    {
        Supplier = supplier;
        Consumer = consumer;
        Ammount = CarryAmmount;
        CurrentStage = TranferStage.GoingToSupplier;
    }



    
}
