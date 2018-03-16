using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.SceneManagement;public class StartMenu : MonoBehaviour
{    public GameObject StartUI;    private bool paused = true;    private void Start()    {        StartUI.SetActive(true);    }

    private void Update()    {        if (Input.GetButtonDown("Pause"))
        {            paused = !paused;        }        if (paused)        {            StartUI.SetActive(true);            Time.timeScale = 0;        }        else        {            StartUI.SetActive(false);            Time.timeScale = 1;        }    }    public void Resume()    {        paused = false;        StartUI.SetActive(false);        Time.timeScale = 1;    }    public void StartGame()
    {        paused = false;        SceneManager.LoadScene(1);    }}