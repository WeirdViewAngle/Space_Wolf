using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameAudioSource : MonoBehaviour   
    {
        
        private void Start()
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Initialize(audioSource);
        }
    }