using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Counter : MonoBehaviour
{
    //public GameObject score_value;
    Text score_value;

    void Start()
    {
        counting_Score();
    }

    public void counting_Score()
    {
        score_value = GameObject.Find("Score").GetComponentInChildren<Text>(); 
        score_value.text = "Score : " + PlayerPrefs.GetInt("Score") + "";
        PlayerPrefs.SetInt("Score", 0);
        

    }
}
