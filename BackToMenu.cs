using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    //private void Start()
    //{
    //    SceneManager.LoadScene("MenuScene");
    //}
    public void BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit Button Pressed");
    }
}
