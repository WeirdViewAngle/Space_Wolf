using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;


public static class AudioManager
    {
        static AudioSource audioSource;
        static Dictionary<AudioNames, AudioClip> audipClips
         = new Dictionary<AudioNames, AudioClip>();

        public static void Initialize(AudioSource audio)
        {
            //configure AudioSource
            audioSource = audio;

            //Fill the dict
            if(!audipClips.ContainsKey(AudioNames.BoostTake))
            {
            audipClips.Add(AudioNames.BoostTake,
            Resources.Load<AudioClip>("BoostTaken"));
            }

            if(!audipClips.ContainsKey(AudioNames.ButtonCheck))
            {
            audipClips.Add(AudioNames.ButtonCheck,
            Resources.Load<AudioClip>("ButtonChose"));
            }

            if(!audipClips.ContainsKey(AudioNames.ButtonClick))
            {
            audipClips.Add(AudioNames.ButtonClick,
            Resources.Load<AudioClip>("ButtonClick"));
            }

            if(!audipClips.ContainsKey(AudioNames.GameOverSound))
            {
            audipClips.Add(AudioNames.GameOverSound,
            Resources.Load<AudioClip>("GameOver"));
            }

            if(!audipClips.ContainsKey(AudioNames.GameplayTheme))
            {
            audipClips.Add(AudioNames.GameplayTheme,
            Resources.Load<AudioClip>("GameplayTheme"));
            }

            if(!audipClips.ContainsKey(AudioNames.MainMenuTheme))
            {
            audipClips.Add(AudioNames.MainMenuTheme,
            Resources.Load<AudioClip>("MenuTheme"));
            }

            if(!audipClips.ContainsKey(AudioNames.Jump))
            {
            audipClips.Add(AudioNames.Jump,
            Resources.Load<AudioClip>("JumpSound"));
            }

            if(!audipClips.ContainsKey(AudioNames.DamageTake))
            {
            audipClips.Add(AudioNames.DamageTake,
            Resources.Load<AudioClip>("DamageTaken"));
            }

        } 

        public static void Play(AudioNames name)
        {
            audioSource.PlayOneShot(audipClips[name]);
        }

        public static void Stop()
        {
            audioSource.Stop();
        }
    }