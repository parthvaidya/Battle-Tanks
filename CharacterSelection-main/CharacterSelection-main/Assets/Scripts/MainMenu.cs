using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;


    void Start()
    {
        // Assign functions to the button click events
        startButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(Quiting);
        

    }
    public void PlayGame()
    {
        //SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
    }


    public void Quiting()
    {
        //SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(2);
    }


}
