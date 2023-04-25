using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkScript : MonoBehaviour
{
    [SerializeField]
    Text instruction;
    BusboyScript busboyScript;
    [SerializeField]
    GameObject dirtyPlate;

    bool isColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        busboyScript = GameObject.FindGameObjectWithTag("busboy").GetComponent<BusboyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (busboyScript.handsAreFull && isColliding)
        {

            instruction.text = "Press Key C to drop dishes in the sink";
            if (Input.GetKeyDown(KeyCode.C))
            {

                busboyScript.handsAreFull = false;
                GameObject dirtyDish=Instantiate(dirtyPlate,this.transform.position,Quaternion.identity);
                dirtyDish.tag = "dirty";
                dirtyDish.transform.rotation= Quaternion.Euler(0f, 0f, -90f);
                Destroy(dirtyDish, 10f);
                
            }
        }
        else if (busboyScript.handsAreFull)
        {
            instruction.text = "Carrying Dishes... Bring them to the sink";
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (busboyScript.handsAreFull)
        {
            if (collision.gameObject.tag == "busboy")
            {
                isColliding = true;

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "busboy")
        {
            instruction.text = "";
            isColliding=false;
        }

    }
}
