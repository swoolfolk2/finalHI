using UnityEngine;

public class GlobalControl : MonoBehaviour 
{
    public static GlobalControl Instance;
    public string[] fields = new string[3];
    public int counter= 0;

    void Awake ()
    {
        
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
}