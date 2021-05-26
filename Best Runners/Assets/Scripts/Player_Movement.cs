using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public float movingSpeed = 10f;

    Vector3 directionToMove = Vector3.zero;
    int position = 1;
    float spaceDifference = Mathf.Abs(Train_Generator.creationPositions[0] - Train_Generator.creationPositions[1]);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(left) && position > 0){
            position -= 1;
            directionToMove = Vector3.left;
        }
        else if(Input.GetKeyDown(right) && position < 2){
            position += 1;
            directionToMove = Vector3.right;
        }

        if(directionToMove == Vector3.left){
            if(transform.position.x > Train_Generator.creationPositions[position]){
                transform.position += directionToMove * movingSpeed * Time.deltaTime;
            }
            else{
                setPosition();
            }
        }
        else if(directionToMove == Vector3.right){
            if(transform.position.x < Train_Generator.creationPositions[position]){
                transform.position += directionToMove * movingSpeed * Time.deltaTime;
            }
            else{
                setPosition();
            }
        }
        
    }

    void setPosition(){
        transform.position = new Vector3(Train_Generator.creationPositions[position], transform.position.y, transform.position.z);
        directionToMove = Vector3.zero;
    }
}
