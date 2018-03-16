using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
	public int SceneToLoad;
    private gameMaster gm;
    private PlayerController player;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

	void OnTriggerEnter2D(Collider2D col){

	}

	void OnTriggerStay2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			if(Input.GetKeyDown("e")){
                SaveScoreAndHealth();
				SceneManager.LoadScene(SceneToLoad);
			}
		}
	}
	void OnTriggerExit2D(){
	
	}

    void SaveScoreAndHealth() {
        PlayerPrefs.SetInt("Health", player.currentHealth);
        PlayerPrefs.SetInt("Points", gm.points);
    }
}
