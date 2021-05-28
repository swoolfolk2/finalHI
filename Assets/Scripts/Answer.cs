using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows.Speech;

/** 
    Class to Get the voice input from the user and store the value.
 */
public class Answer : MonoBehaviour
{
    public GameObject recordMessage; // displayed message for user instructions
    public GameObject continueButton; // button to continue to next step
    private TextMeshProUGUI _result; // displayed message of the voice input
    private bool _giveOrder; // if the command can be detected
    private bool _done; // if is finished
    private DictationRecognizer _dictationRecognizer; // object to detect voice input
    private GameObject _newObj; 
    
    void Start()
    {
        _result = GetComponent<TextMeshProUGUI>();
        _dictationRecognizer = new DictationRecognizer();
        _dictationRecognizer.DictationHypothesis += DetectCommand;
        _dictationRecognizer.Start();
    }

    /**
        Voice detenction function. Detects the text and stores it in [_results]
        @params text value of the voice input
    */
    private void DetectCommand(string text)
    {
        if (!_giveOrder) return;
        _result.text = text;
        _done = true;
        ShowNext();
    }
    private void Update()
    {
        _giveOrder = Input.GetKey(KeyCode.Joystick1Button1);
        if (!Input.GetKey(KeyCode.B) || !_done) return;
        _newObj.GetComponent<Button>().onClick.Invoke();
        var curr = GlobalControl.instance.counter;
        GlobalControl.instance.fields[curr] = _result.text;
        GlobalControl.instance.counter += 1;
    }
    /**
        Displays [continueButton] for the user to be able to continue
    */
    public void ShowNext()
    {
        continueButton.SetActive(true);
        recordMessage.SetActive(false);
        _dictationRecognizer.Stop();
    }
}