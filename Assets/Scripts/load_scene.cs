using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load_scene : MonoBehaviour
{

    // private AudioSource source;
    // public AudioClip click_sound;

    // void Start()
    // {
    //     source = GetComponent<AudioSource>();
    //     source.clip = click_sound;
    // }

    // Start is called before the first frame update
    public void scene_loader(){

       // source.Play();
        SceneManager.LoadScene("Game");
        
    }

    public void Game_Over()
    {
       // source.Play();
        SceneManager.LoadScene("Game_Over");
        
       
    }
    
}
