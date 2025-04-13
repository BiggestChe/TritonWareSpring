using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue_Script : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public float textSpeed;

    private string[] lines;  // Holds the dialogue lines
    private int index;       // Tracks which line is currently displayed
    private bool isDialogueActive = false; // To check if dialogue is active
    private bool isTextFullyDisplayed = false; // Track if text is fully displayed

    // Start is called before the first frame update
    void Start()
    {
        textbox.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0))
        {
            // Check if the text is fully displayed
            if (isTextFullyDisplayed)
            {
                NextLine();
            }
            else
            {
                // Immediately display the full line if text is still being typed
                StopAllCoroutines();
                textbox.text = lines[index];
                isTextFullyDisplayed = true;
            }
        }
    }

    // Triggers the dialogue with multiple lines
    public void TriggerDialogue(string[] dialogueLines)
    {
        lines = dialogueLines;
        index = 0;
        isDialogueActive = true;
        isTextFullyDisplayed = false;
        textbox.text = string.Empty;
        gameObject.SetActive(true);  // Activate the dialogue UI
        StartCoroutine(TypeLine());
    }

    // Triggers the dialogue with a single line
    public void TriggerDialogue(string dialogueLine)
    {
        lines = new string[] { dialogueLine };  // Convert the single line to an array
        index = 0;
        isDialogueActive = true;
        isTextFullyDisplayed = false;
        textbox.text = string.Empty;
        gameObject.SetActive(true);  // Activate the dialogue UI
        StartCoroutine(TypeLine());
    }

    // Coroutine to type out the current dialogue line letter by letter
    IEnumerator TypeLine()
    {
        isTextFullyDisplayed = false;
        foreach (char c in lines[index].ToCharArray())
        {
            textbox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTextFullyDisplayed = true;  // Once typing is done, text is fully displayed
    }

    // Moves to the next line of dialogue, if any
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textbox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    // Ends the dialogue session
    void EndDialogue()
    {
        gameObject.SetActive(false);  // Hide dialogue UI
        isDialogueActive = false;
    }
}
