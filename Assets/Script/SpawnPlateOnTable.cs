using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlateOnTable : MonoBehaviour
{
   
    GameObject[] tables;
    GameObject[] plates;
    [SerializeField]
    int tablesToWash=1;

    void Start()
    {
    tables = GameObject.FindGameObjectsWithTag("table");
    }

    void Update()
    {
        plates = GameObject.FindGameObjectsWithTag("plate");
        if ( plates.Length<=tablesToWash)
        {
            int randomTableIndex = Random.Range(0, tables.Length);
            GameObject selectedTable = tables[randomTableIndex];

            TableScript tableScript = selectedTable.GetComponent<TableScript>();
            tableScript.isDirty = true;
            
        }

        
    }
}
