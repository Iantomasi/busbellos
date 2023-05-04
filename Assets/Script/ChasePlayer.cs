using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{

    Animator animator;


    public GameObject target;
    public float speed;
    private float distance;

    
    //public float bossDistance;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float val_x = Input.GetAxis("Horizontal");
        float val_y = Input.GetAxis("Vertical");

        if (val_y < 0)//then set direction to 2
        {
            animator.SetInteger("direction", (int)MoveDirection.DOWN);
        }

        else if (val_y > 0) //then set direction to 1
        {
            animator.SetInteger("direction", (int)MoveDirection.UP);
        }


        else if (val_x < 0) //then set direction to 3
        {
            animator.SetInteger("direction", (int)MoveDirection.LEFT);
        }


        else if(val_x > 0) //then set direction to 4
        {
            animator.SetInteger("direction", (int)MoveDirection.RIGHT);
        }

       
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        
    }
}


public enum MoveDirection
{
    NONE = 0,
    UP = 1,
    DOWN = 2,
    LEFT = 3,
    RIGHT = 4
}


