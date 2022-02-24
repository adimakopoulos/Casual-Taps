using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Carry a quantity of objects from Supplier(Worldspace Coordinates) to Consumer(Worldspace Coordinates).
/// </summary>
public class TransferOrder
{
    
    public Vector3 FirstSupplier;
    public Vector3[] Suppliers;
    public Vector3 Consumer;
    public int Ammount;
    public enum TranferStage {GoingToSupplier, GoingToSuppliers, Withdrawing,GoingToConsumer , Depositing };
    public TranferStage CurrentStage;
    public TransferOrder(Vector3 supplier, Vector3 consumer, int CarryAmmount)
    {
        FirstSupplier = supplier;
        Consumer = consumer;
        Ammount = CarryAmmount;
        CurrentStage = TranferStage.GoingToSupplier;
    }
    public TransferOrder(Vector3[] suppliers, Vector3 consumer, int CarryAmmount)
    {
        Suppliers = suppliers;
        FirstSupplier = suppliers[0];
        Consumer = consumer;
        Ammount = CarryAmmount;
        CurrentStage = TranferStage.GoingToSuppliers;
    }
    public int GetNumOfSuppliers() {
        return Suppliers.Length;
    }

    public override string ToString() {
        var result = "Suppliers </br> "+" Test" ;

        return result;
    }


}
