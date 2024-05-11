using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames.ServiceLocatorModule;
using UnityEngine;

namespace MiniGames.AudioSystem
{
    public class AudioService:InitializeableMono, IService
    {
        [SerializeField] protected AudioClip[] AudioClips;
        [SerializeField] protected bool[] AudioSourceLoop;
        protected Dictionary<string, AudioSource> AudioSourcesMap = new();
        public AudioService PlaySound(string soundName)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource) && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            return this;
        }

        protected void OnValidate()
        {
            if (AudioSourceLoop.Length!= AudioClips.Length)
                AudioSourceLoop = new bool[AudioClips.Length];
        }

        public void SetGlobalVolume(float volume)
        {
            foreach (var audioSource in AudioSourcesMap)
            {
                audioSource.Value.volume = volume;
            }
        }
        public AudioService SetVolume(string soundName, float volume)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                audioSource.volume = volume;
            }
            return this;
        }
        public AudioService StopPlaySound(string soundName)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                audioSource.Stop();
            }
            return this;
        }

        public AudioService SetLoop(string soundName, bool loop)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                audioSource.loop = loop;
            }
            return this;
        }

        public AudioService SlowMuteSound(string soundName, float time=1f)
        {
            if (TryGetAudioSource(soundName, out AudioSource audioSource))
            {
                StartCoroutine(SlowMuteSoundCoroutine(audioSource, time));
            }

            return this;
        }

        protected IEnumerator SlowMuteSoundCoroutine(AudioSource audioSource, float time)
        {
            float elapsedTime = 0;
            float originalVolume = audioSource.volume;
            while (elapsedTime < time)
            {
                elapsedTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(originalVolume, 0, elapsedTime / time);
                yield return null;
            }
        }
        protected bool TryGetAudioSource(string soundName, out AudioSource audioSource)
        {
            if (AudioSourcesMap.TryGetValue(soundName, out AudioSource audio))
            {
                audioSource = audio;
                return true;
            }
            Debug.LogError($"Failed to find the {soundName} audio");
            audioSource = null;
            return false;
        }

        public override void Init()
        {
            for (var i = 0; i < AudioClips.Length; i++)
            {
                var audioClip = AudioClips[i];
                var name = audioClip.name;
                var audioClipObject = new GameObject(name);
                audioClipObject.transform.SetParent(transform);
                var audioSource = audioClipObject.AddComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.playOnAwake = false;
                audioSource.loop = AudioSourceLoop[i];
                AudioSourcesMap.Add(audioClip.name, audioSource);
            }
        }
    }
}