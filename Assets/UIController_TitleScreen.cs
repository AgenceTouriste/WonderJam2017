using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController_TitleScreen : MonoBehaviour {

    private bool creditsUIactive = false;
    public Transform creditsPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onNewGameButtonClicked()
    {
        // Change scene
        // SceneManager.LoadScene("IntroScene");
    }

    public void onCreditsButtonClicked()
    {
        if (creditsUIactive == false)
        {
            creditsPanel.gameObject.SetActive(true);
            creditsUIactive = true;
        }
        else
        {
            creditsPanel.gameObject.SetActive(false);
            // setting the Back Button Color back to white
            if (creditsPanel.FindChild("BackButton") != null) 
                creditsPanel.FindChild("BackButton").GetComponentInChildren<Text>().color = Color.white;
            creditsUIactive = false;
        }
    }

    public void onQuitButtonClicked()
    {
        Application.Quit();
    }


}
