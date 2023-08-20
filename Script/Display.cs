using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Display : MonoBehaviour
{
    public Text scoreText;
    public Text helText;
    public TMP_InputField playername;
    public Slider _musicSlider, _sfxSlider;

    public Database data;
    ControlForMan man;
    ControlForWoman woman;
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Theme");
        AudioManager.Instance.MusicVolume(data.MusicVolume);
        AudioManager.Instance.SFXVolume(data.SFXVolume);
        man = FindObjectOfType<ControlForMan>();
        woman = FindObjectOfType<ControlForWoman>();
    }
    private void Update()
    {
        if(scoreText != null)
            scoreText.text = "Score: " + data.score.ToString();
        if (helText != null && man != null && woman != null)
        {
            int helth = man.GetComponent<ControlForMan>().helth + woman.GetComponent<ControlForWoman>().helth;
            helText.text = helth.ToString();
            if (helth <= 0)
            {
                AudioManager.Instance.musicSource.Stop();
                AudioManager.Instance.PlaySFX("GameOver");
                if(data.score > data.RecordsList[data.RecordsList.Length - 1].score)
                    SceneManager.LoadScene("Record");
                else
                    SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void SaveRecord()
    {
        data.AddRecord(playername.text, data.score);
        SceneManager.LoadScene("Menu");
    }    
    public void ReStart()
    {
        SceneManager.LoadScene("GameArea");
    }    
    public void Play()
    {
        SceneManager.LoadScene("GameArea");
    }    
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }    
    public void Back()
    {
        data.MusicVolume = _musicSlider.value;
        data.SFXVolume = _sfxSlider.value;
        SceneManager.LoadScene("Menu");
    }    

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Record()
    {
        SceneManager.LoadScene("RecordTable");
    } 
    
    public void RecordBack()
    {
        SceneManager.LoadScene("Menu");
    }    

    public void DeveloperMode()
    {
        SceneManager.LoadScene("DeveloperMode");
    }    
}
