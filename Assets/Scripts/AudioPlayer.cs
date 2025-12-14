using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip Intro;
    public AudioClip Loop;

    private AudioSource audioSource; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.resource = Intro;
        
        audioSource.Play();
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.time == Intro.length)
        {
            audioSource.resource = Loop;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
}
