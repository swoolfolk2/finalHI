using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows.Speech;


public class Answer : MonoBehaviour
{
    public GameObject recordMessage;
    private TextMeshProUGUI _Result;
    private string _mainCall;
    private bool _giveOrder;
    private bool _continue;
    private bool _done;
    private DictationRecognizer dictationRecognizer;
    public GameObject continueButton;
    public Transform containerTransform;
    private GameObject newObj;
    private string message = "";
    void Start()
    {
        _Result = GetComponent<TextMeshProUGUI>();
        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationHypothesis += DetectCommand;
        dictationRecognizer.Start();
    }
    private void DetectCommand(string text)
    {
        if (!_giveOrder) return;
        _Result.text = text;
        _done = true;
        showNext();
    }
    private void Update()
    {
        _giveOrder = Input.GetKey(KeyCode.A);
        if (!Input.GetKey(KeyCode.B) || !_done) return;
        newObj.GetComponent<Button>().onClick.Invoke();
        var curr = GlobalControl.Instance.counter;
        GlobalControl.Instance.fields[curr] = _Result.text;
        GlobalControl.Instance.counter += 1;
    }
    public void showNext()
    {
        continueButton.SetActive(true);
        recordMessage.SetActive(false);
        dictationRecognizer.Stop();
    }
}