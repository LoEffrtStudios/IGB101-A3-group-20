using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject player;
    //Pickup and Level Complection Logic
    public int currentPickups =1;
    public int maxPickups=5;
    public bool levelComplete=false;
    public Text pickupText;
    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;
    private void LevelCompleteCheck()
    {
        if (currentPickups >=maxPickups)
        {
            levelComplete=true;
        }
        else
        {
            levelComplete=false;
        }
    }
    private void UpdateGUI()
    {
        pickupText.text ="Pickup: " + currentPickups + "/" + maxPickups;
    }
    //Loop for playing audio proximity events- audioSource based
    private void PlayAudioSamples()
    {
        for(int i=0; i< audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position)<= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }
}
