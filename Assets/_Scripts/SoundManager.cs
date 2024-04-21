using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance { get; private set; }
	private AudioSource source;

	private void Awake()
	{
		instance = this;
		source = GetComponent<AudioSource>();
	}

	public void PlaySound(AudioClip sound)
	{
		source.PlayOneShot(sound);
	}

	public void PlayDelayedSound(AudioClip sound, float delay)
	{
		StartCoroutine(PlayDelayedSoundCoroutine(sound, delay));
	}

	private IEnumerator PlayDelayedSoundCoroutine(AudioClip sound, float delay)
	{
		yield return new WaitForSeconds(delay);
		PlaySound(sound);
	}
}

