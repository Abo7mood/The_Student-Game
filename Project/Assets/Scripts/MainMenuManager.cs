using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    //mainmanuscene load 
   public void MainMenu() => SceneManager.LoadScene("MainUIScene");
    //The level1 scene load 
    public void FirstScene() => SceneManager.LoadScene("MainScene");
    //appilcation exit code
    public void ExitApplication() => Application.Quit();






}
