using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Image load_bar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        StartCoroutine(SceneShift());
    }

    IEnumerator SceneShift()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");        

    }

    // Update is called once per frame
    void Update()
    {
       load_bar.fillAmount += .1F; 
    }
}
