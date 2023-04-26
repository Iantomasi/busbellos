using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public float healthDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D enemy)
    {
       if(enemy.gameObject.CompareTag("Player")) {

            enemy.gameObject.GetComponent<FamilyHealthBar>().health -= healthDamage;
        }
    }


}
