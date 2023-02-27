using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject dissolve;
    public GameManager gameManager;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void OnMouseDown()
    {
        if(textComponent.text == lines[index])
        {
            NextLine();
        }
    }

    private void OnMouseExit()
    {
        if(textComponent.text != lines[index])
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        //for (int i = 0; i < lines.Length; i++)
        //{
        //    textComponent.text = lines[i];
        //    lines[i - 1].SetActive(false);
        //    StartCoroutine(TypeLine());

        //}
        //if (int i > lines.Length)
        //{
        //    gameObject.SetActive(false);
        //}

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dissolve.SetActive(true);
            gameObject.SetActive(false);
            gameManager.Animation(1, 1);
        }
    }
}
