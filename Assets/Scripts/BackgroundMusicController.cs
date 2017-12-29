using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip[] SoundtrackClips;

    private AudioSource _audio;

    // Use this for initialization
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        if (_audio.playOnAwake) return;
        _audio.clip = SoundtrackClips[Random.Range(0, SoundtrackClips.Length)];
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (_audio.isPlaying) return;
        _audio.clip = SoundtrackClips[Random.Range(0, SoundtrackClips.Length)];
        _audio.Play();
    }
}