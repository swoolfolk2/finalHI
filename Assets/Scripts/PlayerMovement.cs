using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public float movingSpeed = 10f;

    Vector3 directionToMove = Vector3.zero;
    int position = 1;
    float spaceDifference = Mathf.Abs(TrainGenerator.creationPositions[0] - TrainGenerator.creationPositions[1]);

    public void MoveLeft()
    {
        if (position > 0)
        {
            position -= 1;
            directionToMove = Vector3.left;
        }
    }
    public void MoveRight()
    {
        if (position < 2)
        {
            position += 1;
            directionToMove = Vector3.right;
        }
    }
    private void Update()
    {
        if (directionToMove == Vector3.left)
        {
            if (transform.position.x > TrainGenerator.creationPositions[position])
            {
                transform.position += directionToMove * movingSpeed * Time.deltaTime;
            }
            else
            {
                setPosition();
            }
        }
        else if (directionToMove == Vector3.right)
        {
            if (transform.position.x < TrainGenerator.creationPositions[position])
            {
                transform.position += directionToMove * movingSpeed * Time.deltaTime;
            }
            else
            {
                setPosition();
            }
        }

    }
    private void setPosition()
    {
        transform.position = new Vector3(TrainGenerator.creationPositions[position], transform.position.y, transform.position.z);
        directionToMove = Vector3.zero;
    }
}
