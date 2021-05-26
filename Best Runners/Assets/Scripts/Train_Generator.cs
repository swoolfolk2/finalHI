using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_Generator : MonoBehaviour
{
    public GameObject trainPrefab;
    GameObject lastTrainCreated;
    public int[] sizeLimits = {30, 100};
    static public float[] creationPositions = {-6.5f, 0, 6.5f};

    float timer = 0;
    float lastSize = 30;
    Vector3 lastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;

        for(int i = 0;i< 10;i++){
            createNewTrain(getRandomPosition());
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        print(timer);
        
        if(timer >= lastSize /10 / Train_Movement.speed){
            timer = 0;
            createNewTrain(getRandomPosition());
        }
        

    }

    void createNewTrain(Vector3 position){
        GameObject newTrain = Instantiate(trainPrefab);
        
        newTrain.transform.localScale = getRandomScale();
        newTrain.transform.position = position + Vector3.forward * newTrain.transform.localScale.z / 2;
        lastTrainCreated = newTrain;
        lastSize = newTrain.transform.localScale.z;
        lastPosition = newTrain.transform.position + Vector3.forward * newTrain.transform.localScale.z / 2;

    }

    Vector3 getRandomScale(){
        Random rnd = new Random();
        int newZ = Random.Range(sizeLimits[0], sizeLimits[1]);
        
        return new Vector3(6,9,newZ);
    }

    Vector3 getRandomPosition(){
        Random rnd = new Random();
        double newX = Random.Range(0, 2);
        
        Vector3 positionToCreate = new Vector3(creationPositions[(int)newX],lastPosition.y,lastPosition.z);

        return positionToCreate;
    }
}
