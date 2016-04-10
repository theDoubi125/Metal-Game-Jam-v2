using UnityEngine;
using System.Collections;

public class AmbianceMusic : MonoBehaviour {

    private AudioSource audioSource;
    private AudioLowPassFilter lowFilter;

    public AudioClip[] backgroundMusics;

    public int musicIndex = 0;

    public bool isFilter = false;

    public int minLowFilter = 400;



    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        lowFilter = GetComponent<AudioLowPassFilter>();
        audioSource.clip = backgroundMusics[musicIndex];
        audioSource.Play();

    }


    void NextSound()
    {
        musicIndex++;
        if (musicIndex >= backgroundMusics.Length) musicIndex = 0;
        audioSource.clip = backgroundMusics[musicIndex];
        audioSource.Play();
    }


        // Update is called once per frame
        void Update () {

        if (!audioSource.isPlaying)
            NextSound();
        
        if(isFilter)
        {
            if (lowFilter.cutoffFrequency > 1000)
                lowFilter.cutoffFrequency -= 10500*Time.deltaTime;
            else if (lowFilter.cutoffFrequency > minLowFilter)
                lowFilter.cutoffFrequency -= 300 * Time.deltaTime;
            else
                lowFilter.cutoffFrequency = minLowFilter;
        }
        else
        {
            if (lowFilter.cutoffFrequency < minLowFilter)
                lowFilter.cutoffFrequency += 300 * Time.deltaTime;
            else if (lowFilter.cutoffFrequency < 22000)
                lowFilter.cutoffFrequency += 3000 * Time.deltaTime;
            else
                lowFilter.cutoffFrequency = 22000;
        }

    }
}
