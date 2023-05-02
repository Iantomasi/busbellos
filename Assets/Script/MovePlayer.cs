using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    Animator animator;
    public float speed;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 1;
        float val_x = Input.GetAxis("Horizontal");
        float val_y = Input.GetAxis("Vertical");

        if (val_y < 0)//then set direction to 2
        {
            animator.SetInteger("direction", (int)MoveDirectionPlayer.DOWN);
        }

        else if (val_y > 0) //then set direction to 1
        {
            animator.SetInteger("direction", (int)MoveDirectionPlayer.UP);
        }

        else if (val_x < 0) //then set direction to 3
        {
            animator.SetInteger("direction", (int)MoveDirectionPlayer.LEFT);
        }

        else if (val_x > 0) //then set direction to 4
        {
            animator.SetInteger("direction", (int)MoveDirectionPlayer.RIGHT);
        }

        else
        {

            animator.speed = 0;

        }

        // step 3 add rb2d.moveposition
        Vector3 playerPosition = transform.position += new Vector3(val_x, val_y, 0).normalized * speed * Time.deltaTime;
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        playerPosition.y = Mathf.Clamp(playerPosition.y, minY, maxY);
        transform.position = playerPosition;
        Debug.Log(transform.position);
    }
}

public enum MoveDirectionPlayer
{
    NONE = 0,
    UP = 1,
    DOWN = 2,
    LEFT = 3,
    RIGHT = 4
}

