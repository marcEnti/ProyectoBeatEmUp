using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] bool canPlayerMove = true;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject player;

    enum Direction { Up, Down, Left, Right }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveCharacter(Direction.Up);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveCharacter(Direction.Down);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveCharacter(Direction.Right);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveCharacter(Direction.Left);
        }
      
    }

    void MoveCharacter(Direction direction)
    {
        switch(direction)
        {
            case Direction.Up:
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + (speed * 0.01f), player.transform.position.z);
                break;
            case Direction.Down:
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - (speed * 0.01f), player.transform.position.z);
                break;
            case Direction.Left:
                player.transform.position = new Vector3(player.transform.position.x - (speed * 0.01f), player.transform.position.y, player.transform.position.z);
                break;
            case Direction.Right:
                player.transform.position = new Vector3(player.transform.position.x + (speed * 0.01f), player.transform.position.y, player.transform.position.z);
                break;
            default:
                break;
        }
    }
        
}
