using UnityEngine;

/**
    Class to manage all fields and answers by Player
*/
public class GlobalControl : MonoBehaviour 
{
    public static GlobalControl instance; // This instance
    public string[] fields = new string[3]; // Fields to fill by user
    public int counter= 0; // current counter of fields

    void Awake ()
    {
        
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
    }
}