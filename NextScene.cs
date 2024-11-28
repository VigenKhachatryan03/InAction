using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Bone()
    {
        SceneManager.LoadScene("InAction1");
    } 
    public void GroundDetection()
    {
        SceneManager.LoadScene("GroundDetection");
    } 
    public void CoubeRotation()
    {
        SceneManager.LoadScene("InAction2");
    }
    public void exitgame()
    {
        Application.Quit();
        Debug.Log("Exit Button pressed");
    }
}
