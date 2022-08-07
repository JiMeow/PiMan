using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    Text number;
    [SerializeField]
    Text current_pi;
    GameObject[] buttons;
    void Start()
    {
        number = GetComponent<Text>();
        Transform[] buttonsTransfrom = GetComponentsInChildren<Transform>();
        buttons = new GameObject[3];
        int diff = 0;
        for (int i = 0; i < buttonsTransfrom.Length; i++)
        {
            if (buttonsTransfrom[i].name != "Text (Legacy)" && buttonsTransfrom[i].name != "ChoiceManager"
                && buttonsTransfrom[i].name != "RestartButton" && buttonsTransfrom[i].name != "Score")
            {
                buttons[i - diff] = buttonsTransfrom[i].gameObject;
            }
            else
            {
                diff++;
            }
        }
        SetNumber();
    }

    public void SetNumber()
    {
        int[] array = new int[3];
        CheckAns choiceManager = GameObject.Find("EventSystem").GetComponent<CheckAns>();
        int size = choiceManager.GetSize();
        string str = choiceManager.GetAnswer();
        char c = str[size];
        array[0] = c - '0';

        for (int i = 1; i < 3; i++)
        {
            array[i] = (array[0] + Random.Range(1, 9)) % 10;
        }
        if (array[1] == array[2])
        {
            array[2] = (array[2] + 1) % 10;
            if (array[2] == array[0])
            {
                array[2] = (array[2] + 1) % 10;
            }
        }

        Sort(array);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = array[i].ToString();
        }
    }

    public void Sort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
