using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject Dialogues;
    public Text dialogueText;

    public List<string> Lines = new List<string>();
    public float speedText = 0.06f;

    private int index;

    private void Start()
    {
        Lines.Add("Test1");
        Lines.Add("Test2");
        Lines.Add("Test3");

        dialogueText.text = string.Empty;
        if (Lines != null && Lines.Count > 0)
        {
            StartDialogue();
            Debug.Log("Worked");
        }
        else
        {
            Debug.LogError("NumofData = " + Lines.Count + " + Lines = " + Lines);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void SkipTextClick()
    {
        if (dialogueText.text == Lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = Lines[index];
        }
    }

    private void NextLine()
    {
        if (index < Lines.Count - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
