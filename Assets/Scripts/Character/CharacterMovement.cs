using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool canPlayerMove = true;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject player;
    bool lookingRight = true;
    enum Direction { UP, DOWN, LEFT, RIGHT }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canPlayerMove)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveCharacter(Direction.UP);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveCharacter(Direction.DOWN);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveCharacter(Direction.RIGHT);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveCharacter(Direction.LEFT);
            }
        }
      
    }

    void MoveCharacter(Direction direction)
    {
        switch(direction)
        {
            case Direction.UP:
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + (speed * 0.01f), player.transform.position.z);
                break;
            case Direction.DOWN:
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - (speed * 0.01f), player.transform.position.z);
                break;
            case Direction.LEFT:
                player.transform.position = new Vector3(player.transform.position.x - (speed * 0.01f), player.transform.position.y, player.transform.position.z);
                if(lookingRight)
                {
                    // Turn Sprite of character
                
                    lookingRight = false;
                }
                break;
            case Direction.RIGHT:
                player.transform.position = new Vector3(player.transform.position.x + (speed * 0.01f), player.transform.position.y, player.transform.position.z);
                if(!lookingRight)
                {
                    // Turn Sprite of character
         
                    lookingRight = true;
                }
                break;
            default:
                break;
        }
    }
        
}
