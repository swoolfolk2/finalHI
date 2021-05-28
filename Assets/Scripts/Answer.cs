using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows.Speech;


public class Answer : MonoBehaviour
{
    public GameObject recordMessage;
    private TextMeshProUGUI result;
    private bool giveOrder;
    private bool done;
    private DictationRecognizer dictationRecognizer;
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