using UnityEngine;
using UnityEngine.UI;

public class MessageIFFontFixer : MonoBehaviour
{
    public string messageContent;

    //void OnEnable()
    //{
    //    this.GetComponent<InputField>().onEndEdit.AddListener(delegate
    //    {
    //        OnEndEditHanlder();
    //    });
    //}

    public void OnEndEditHanlder()
    {
        messageContent = this.GetComponent<InputField>().text;
        this.GetComponent<InputField>().text = ArabicSupport.ArabicFixer.Fix(this.GetComponent<InputField>().text);
    }

    void Update()
    {
        //FixIFText();
    }

    void FixIFText()
    {
        string content = this.GetComponent<InputField>().text;
        string prev = string.Empty;
        if (!(string.IsNullOrEmpty(content)) && !(prev == content))
        {
            this.GetComponent<InputField>().text = ArabicSupport.ArabicFixer.Fix(content);
            prev = this.GetComponent<InputField>().text;
        }
    }
}
