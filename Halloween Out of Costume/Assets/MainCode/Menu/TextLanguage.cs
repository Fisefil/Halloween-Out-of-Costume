using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLanguage : MonoBehaviour
{
    public string language;
    Text text;

    public string textEng;
    public string textRu;
    public string textFr;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        language = PlayerPrefs.GetString("Language");

        if(language == "" ||  language == "Eng")
        {
            text.text = textEng;
        }
        else if(language == "Ru")
        {
            text.text = textRu;
        }
        else if (language == "French")
        {
            text.text = textFr;
        }
    }
}
