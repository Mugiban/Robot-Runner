﻿using System.Collections.Generic;
using ID.Utilities;
using UnityEngine;

namespace ID.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] [Range(0,20)] private int numberOfAudioSources = 10;
        private static List<AudioSource> AudioSources;

        protected override void Awake()
        {
            base.Awake();
            CreateAudioSources(numberOfAudioSources);
        }

        private void Update()
        {
            foreach (var audioSource in AudioSources)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.gameObject.SetActive(false);
                }
            }
        }

        private void CreateAudioSources(float number)
        {
            AudioSources = new List<AudioSource>();
            for (int i = 0; i < number; i++)
            {
                CreateAudioSource();
            }
        }

        private AudioSource CreateAudioSource()
        {
            var go = new GameObject("Audio Source");
            go.transform.parent = transform;
            var audioSource = go.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            AudioSources.Add(audioSource);
            return audioSource;
        }

        public static void PlaySound(AudioClip audioClip)
        {
            var audioSource = Instance.GetAudioSource();
            audioSource.clip = audioClip;
            audioSource.volume = .5f;
            audioSource.pitch = UnityEngine.Random.Range(.98f, 1.02f);
            audioSource.loop = false;
            audioSource.PlayOneShot(audioClip);
        }

        private  AudioSource GetAudioSource()
        {
            foreach (var source in AudioSources)
            {
                if (!source.isPlaying)
                {
                    source.gameObject.SetActive(true);
                    return source;
                }
            }
            
            return CreateAudioSource();
        }
    } 
}
