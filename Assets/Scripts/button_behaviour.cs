using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_behaviour : MonoBehaviour

{
    private Button button;
    [SerializeField]
    private Image slash;


    public void click_button(Text letter)
    {
       string p = letter.text;
       GameObject Main_instance = GameObject.Find("Game");
       Main_instance.GetComponent<Main_Game>().getGuess(p);
       button = GetComponentInChildren<Button>();
       button.interactable = false;
       slash.enabled = true;
    }

}
