using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRecord : MonoBehaviour
{
    public Database data;
    public TextMeshProUGUI[] PlayerName;
    public TextMeshProUGUI[] Score;
    void Awake()
    {
       for(int i = 0; i < PlayerName.Length; i++)
        {
            PlayerName[i].text = data.RecordsList[i].name;
            Score[i].text = data.RecordsList[i].score.ToString();
        }    
    }
}
