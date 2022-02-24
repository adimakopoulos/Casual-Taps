
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(WorkerManager))]
public class TransferJobView : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WorkerManager worker = (WorkerManager)target;

        GUILayout.Label("TRANSFER ORDERS");
        var orders = worker.GetCurrentOrders();
        if (orders == null)
            return;
        GUILayout.Label(" ");

        EditorGUILayout.Vector3Field("Cunsumer: ", orders.Consumer);
        for (int i = 0; i < orders.Suppliers.Length; i++)
        {
            EditorGUILayout.Vector3Field("Supplier" + i + ": ", worker.GetCurrentOrders().Suppliers[i]);
        }

    }






    private void OnGUI()
    {
        Vector3 Supplier, Consumer;
        TransferOrder to;
        GameObject go;

        //Supplier = EditorGUILayout.ObjectField("Queue ", Supplier);



    }
}
