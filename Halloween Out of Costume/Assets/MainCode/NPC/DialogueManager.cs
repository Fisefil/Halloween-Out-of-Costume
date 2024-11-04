using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Button npcButton;

    private string[] dialogueLines;
    private int currentLineIndex;
    private float typingSpeed = 0.05f;
    private bool isTyping;

    void Start()
    {
        dialoguePanel.SetActive(false);

        dialogueLines = new string[]
        {
            "First",
            "Second",
            "Third"
        };

        npcButton.onClick.AddListener(StartDialogue);
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextLine();
        }
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        currentLineIndex = 0;
        ShowLine();
    }

    private void ShowLine()
    {
        if (!isTyping)
        {
            StopAllCoroutines();
            StartCoroutine(TypeLine(dialogueLines[currentLineIndex]));
        }
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
