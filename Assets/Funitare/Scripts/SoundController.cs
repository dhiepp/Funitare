using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
	private static AudioSource PlaceSound;
	private static AudioSource PopSound;
	private static AudioSource CaptureSound;

    void Start()
    {
		List<AudioSource> audioSources = new List<AudioSource>();
		GetComponents(audioSources);
		PlaceSound = audioSources[0];
		PopSound = audioSources[1];
		CaptureSound = audioSources[2];
    }
    
	public static void PlayPlaceSound()
	{
		PlaceSound.PlayOneShot(PlaceSound.clip);
	}

	public static void PlayPopSound()
	{
		PopSound.PlayOneShot(PopSound.clip);
	}

	public static void PlayCaptureSound()
	{
		CaptureSound.PlayOneShot(CaptureSound.clip);
	}
}
