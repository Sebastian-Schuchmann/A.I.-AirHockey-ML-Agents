using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    private int redScore = 0;
    private int blueScore = 0;

    public void AddRedScore()
    {
        redScore++;
        Display();
    }

    public void AddBlueScore()
    {
        blueScore++;
        Display();
    }

    private void Display()
    {
        GetComponent<TextMeshProUGUI>().text = $"{redScore} - {blueScore}";
    }
}
