using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows.Speech;

/** 
    Class to Get the voice input from the user and store the value.
 */
public class Answer : MonoBehaviour
{
    public GameObject recordMessage; // button to continue to next step
    private TextMeshProUGUI result; // displayed message of the voice input
    private bool giveOrder; // if the command can be detected
    private bool done; // if is finished
    private DictationRecognizer dictationRecognizer; // object to detect voice input
    public GameObject continueButton;
    private int startingCounter = 0;
    void Start()
    {
        startingCounter = GlobalControl.fields.Count;
        result = GetComponent<TextMeshProUGUI>();
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationHypothesis += DetectCommand;
        dictationRecognizer.Start();
    }

    /**
        Voice detenction function. Detects the text and stores it in [_results]
        @params text value of the voice input
    */
    private void DetectCommand(string text)
    {
        if (!giveOrder) return;
        result.text = text;
        done = true;
        ShowNext();
    }
    private void Update()
    {
        giveOrder = Input.GetKey(KeyCode.Joystick1Button1);
    }
    
    /**
        Displays [continueButton] for the user to be able to continue
    */
    public void ShowNext()
    {
        dictationRecognizer.Stop();
        continueButton.SetActive(true);
        recordMessage.SetActive(false);
        GlobalControl.fields.Add(result.text);
        if (GlobalControl.fields.Count > startingCounter + 1)
        {
            GlobalControl.fields.RemoveAt(GlobalControl.fields.Count - startingCounter - 1);
        }
    }
}