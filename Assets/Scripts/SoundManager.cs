using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip deadth, jump;

    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    private bool muted = false;
    // Start is called before the first frame update

    private void Awake()
    {
        AudioListener.pause = muted;
    }


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        muted = false;
        UpdateButtonIcon(muted);
        AudioListener.pause = muted;
    }

    public void OnbuttonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon(muted);
    }

    private void UpdateButtonIcon(bool muted)
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1; 
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathSound()
    {
        source.clip = null;
        source.clip = deadth;
        source.Play();
    }

    public void StairSound()
    {
        source.clip = null;
        source.clip = jump;
        source.Play();
    }
}
