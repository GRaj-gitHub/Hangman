using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.IO;

public class Main_Game : MonoBehaviour
{
    TextAsset temp_text;
    string word_dict;
    string temp = null;
    string answer;
    [SerializeField]
    private GameObject blankPrefab;
    private GameObject letterTemp;
    private Transform option; // for button text
    private Transform option2; // for blank text
    private Transform option3; // for button image
    public Transform letterContainer;
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    public  string options = "abcdefghijklmnopqrstuvwxyz";
    [SerializeField]
    private Image[] img = new Image[6];
    public List<string> answer_set = new List<string>();
    private bool work = true; //to set button not interactable;
    
   
    int guessed;         // to find the index of the guessed word
    int img_no = 0;      // to display hangman in order
    int count = 0;       // to count the no og strings in the list
    int scores;       // to count the score
    int score_count = 1;
    private GameObject[] button = new GameObject[26];
    

    
    // Start is called before the first frame update
    void Start()
    { 
       buttonPrefab.SetActive(true); 
       TextAsset temp_text = Resources.Load("wordlist") as TextAsset; //loading the text file from the folder to temp_text
       Debug.Log(temp_text.text);
       word_dict = temp_text.text;
       for(int i = 0; i < word_dict.Length; i++)
       {
           temp += word_dict[i]; //concatinating each leter upto newline into the string temp
           if(word_dict[i] == '\n')
           {
             count++; // count of total strings
             answer_set.Add(temp);  //each string is an element of the list 
             temp = null; // initializing the string back to null;
             
           }
       }
       // assigning a reandom value to answer
       setBlankLetter();

    }

    // Update is called once per frame
    void Update()
    { 
        
    }


    // Adding blanks and keyboard Buttons on the screen
    private void setBlankLetter()
    {
        answer = answer_set[Random.Range(0, count - 1)];
        Debug.Log("answer =  " + answer);
        Debug.Log(answer.Length);
        Debug.Log(options);
        for (int i = 0; i < answer.Length - 1; i++)
        {
            GameObject blankTemp = Instantiate(blankPrefab,letterContainer);
            blankTemp.name = "blank" + i ;      // naming tne blanks to locate
            
        }

        for (int i = 0; i < 26; i++)
        {
            
                letterTemp = Instantiate(buttonPrefab,buttonContainer);
                option = letterTemp.transform.Find("Text") as Transform;  // finding the text of each button prefab
                option.GetComponent<Text>().text = options[i] + ""; // + "" is to convert to string
                letterTemp.name = "letter" + i ;
                button[i] = letterTemp;
                
         }
    }


    //guessing the letters of the word
    public void getGuess(string guess)
    {

        Debug.Log(guess);
        // Finding the index of the guessed charecter in the answer; if not present index is -1
        guessed = answer.IndexOf(guess);
        Debug.Log(guessed);
       if (guessed == -1)
       {
           hang();
        
        }

       else
       {
            
            for (int j = 0; j < answer.Length; j++) 
            {
                if (answer[j] == guess[0])
                {
                   Debug.Log("letter found " + j +" position");
                   option2 = letterContainer.transform.Find("blank" + j) as Transform;  
                   option2.GetComponentInChildren<Text>().text = answer[guessed] + ""; 
                   score_count++;

                   if(score_count == answer.Length)
                   {
                       scores = PlayerPrefs.GetInt("Score");
                       scores++;
                       PlayerPrefs.SetInt("Score", scores);
                       Debug.Log("total score = " + scores);
                       disable_buttons();
                   }                  
                }
                
            }       
             
       }

       if(img_no == 6)
       {
           for(int j =0; j < answer.Length; j++)
           {
               option2 = letterContainer.transform.Find("blank" + j) as Transform;  
               option2.GetComponentInChildren<Text>().text = answer[j] + "";
               disable_buttons();
           }
    
            
       }
        

    }


    public void hang()
    {
        img[img_no].DOFillAmount(1, 1);   //to fillamount using dotweeen
        img_no++;
        

    }

    public void disable_buttons()
    {
       for(int i = 0; i < 26; i++)
       {
           button[i].SetActive(false);
       }
    }



}
