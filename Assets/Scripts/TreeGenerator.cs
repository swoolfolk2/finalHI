using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;

        for(int i = 0; i < 100;i++){
            position += Vector3.forward * 2;
            if( i % 2 == 0){
                position = new Vector3(10, 0, position.z);
            }
            else{
                 position = new Vector3(-10, 0, position.z);
            }
            GameObject newTree = Instantiate(treePrefab);
            newTree.transform.position = position;
        }
    }
}