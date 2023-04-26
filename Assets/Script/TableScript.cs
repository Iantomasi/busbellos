using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableScript : MonoBehaviour
{
    [SerializeField]
    Text instruction;
    public bool isDirty = false;
    [SerializeField]
    GameObject dirtyDish;
    bool tableIsFull = false;
    bool canClean = false;
    GameObject dirtyPlate;
    BusboyScript busboyScript;
    // Start is called before the first frame update
    void Start()
    {
       busboyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BusboyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isDirty && !tableIsFull)
        {
            Vector3 spawnPosition = this.transform.position;
            spawnPosition.x += 0.2f;
            dirtyPlate = Instantiate(dirtyDish, spawnPosition, Quaternion.identity);
            tableIsFull = true;
        }

        if (this.isDirty && tableIsFull)
        {
            if (Input.GetKeyDown(KeyCode.C) && canClean)
            {
           
                busboyScript.handsAreFull = true;
                Destroy(dirtyPlate);
                isDirty = false;
                tableIsFull = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.isDirty && !busboyScript.handsAreFull)
        {
            if (collision.gameObject.tag == "Player")
            {
                instruction.text = "Press Key C to clean table";
                canClean = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                instruction.text = "";
            }

    }
}