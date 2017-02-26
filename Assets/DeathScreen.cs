using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

    public GameObject ds;
    private bool isDead = false;

    void Update ()
    {
        if (isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1.0F;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    public void OnDeath()
    {
        ds.SetActive(true);
        isDead = true;
    }
}
