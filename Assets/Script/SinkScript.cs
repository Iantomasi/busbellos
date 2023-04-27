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
    FamilyHealthBar healthBar;

    bool isColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        busboyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BusboyScript>();
        healthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<FamilyHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (busboyScript.handsAreFull && isColliding)
        {

            instruction.text = "Press Key C to drop dishes in the sink";
            if (Input.GetKeyDown(KeyCode.C))
            {
                healthBar.Heal();
                busboyScript.handsAreFull = false;
                GameObject dirtyDish=Instantiate(dirtyPlate,this.transform.position,Quaternion.identity);
                dirtyDish.tag = "dirty";
                dirtyDish.transform.rotation= Quaternion.Euler(0f, 0f, -90f);
                Destroy(dirtyDish, 10f);
                instruction.text = "";
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
            if (collision.gameObject.tag == "Player")
            {
                isColliding = true;

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            instruction.text = "";
            isColliding=false;
        }

    }
}
