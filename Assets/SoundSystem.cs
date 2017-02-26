using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSystem : MonoBehaviour {

    public AudioClip[] larsenclips;
    public AudioClip[] distractclips;
    public AudioClip[] blameclips;
    public AudioClip[] orderclips;
    public AudioClip[] gameoverclips;

    public Text[] distracttext;
    public Text[] blametext;
    public Text[] ordertext;
    public Text[] gameovertext;

    AudioSource m_audiosource;


    public void Start()
    {
        m_audiosource = GetComponent<AudioSource>();
    }

    public void PlayDistract()
    {
        m_audiosource.clip = distractclips[Random.Range(0, distractclips.Length)];
        m_audiosource.Play();
    }

    public void PlayBlame()
    {
        m_audiosource.clip = blameclips[Random.Range(0, blameclips.Length)];
        m_audiosource.Play();
    }

    public void PlayOrder()
    {
        m_audiosource.clip = orderclips[Random.Range(0, orderclips.Length)];
        m_audiosource.Play();
    }

    public void PlayGameOver()
    {
        m_audiosource.clip = gameoverclips[Random.Range(0, gameoverclips.Length)];
        m_audiosource.Play();
    }

    public void PlayLarsen()
    {
        m_audiosource.clip = larsenclips[Random.Range(0, larsenclips.Length)];
        m_audiosource.Play();
    }
}
