using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameMaster : MonoBehaviour {


	public int points;
	public Text pointsText;
    private PlayerController player;


    private void Start()
    {
        if (PlayerPrefs.HasKey("Points")) {
            if (SceneManager.GetActiveScene().buildIndex == 0) {
                PlayerPrefs.DeleteKey("Points");
                points = 0;
            }
            else
            {
                points = PlayerPrefs.GetInt("Points");
            }
        }
        if (PlayerPrefs.HasKey("Health"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("Health");
            }
            else
            {
                player.SetHealth(PlayerPrefs.GetInt("Health"));
            }
        }
    }

    void Update () {
        pointsText.text = ("Points: " + points);
	}
}
