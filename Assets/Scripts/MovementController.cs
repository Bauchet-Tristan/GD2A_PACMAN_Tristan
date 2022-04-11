using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject currentNode;
    public float speed = 3f; 

    public string direction = "";
    public string lastMovingDirection = "";

    public bool isGhost = false;

    // Start is called before the first frame update
    void Start()
    {
        lastMovingDirection = "left";
    }

    // Update is called once per frame
    void Update()
    {
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);

        //Figure out if we're at the center of our node
        if (transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y)
        {

            if(isGhost)
            {
                GetComponent<EnemyController>().ReachedCenterOfNode(currentNodeController);
            }

            //get the next node from our node controller
            GameObject newNode = currentNodeController.GetNodeFromDirection(direction);
            if (newNode != null)
            {
                currentNode = newNode;
                lastMovingDirection = direction;
            }
            //we can't move in desired direction, try to kee going in the last direction
            else
            {
                direction = lastMovingDirection;
                newNode = currentNodeController.GetNodeFromDirection(direction);
                if (newNode != null)
                {
                    currentNode = newNode;
                }
            }
        }
    }

    public void SetDirection(string newDirection)
    {
        direction = newDirection;
    }

}
