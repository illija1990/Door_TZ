using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager UInstance { get; set; }
    public GameObject StartText, WinText;


    private void Awake()
    {
        UInstance = this;
    }

    private void Start()
    {
        WinText.SetActive(false);
        StartText.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartGame();
            }
        }
        if(WinText.activeSelf == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                Restart();
            }
        }
    }
   
    public void StartGame()
    {
        Time.timeScale = 1;
        StartText.SetActive(false);
    }

    public void Win()
    {
        WinText.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
