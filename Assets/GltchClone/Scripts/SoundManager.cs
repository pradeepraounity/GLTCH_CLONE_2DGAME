using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour 
{

	public static Action onGameBgSoundPlay;
	public static Action onGameBgUISoundPlay;
	public static Action onBgSoundStop;
	public static Action onGameOverSoundPlay;
	public static Action onCollectSoundPlay;

	[Header("Audio Source")]
	public AudioSource _audioSourceMain;
	public AudioSource _audioSourceOnce;


	[Header("Audio Clips")]
	public AudioClip uiBgClip;
	public AudioClip[] gameBgClip;
	public AudioClip collectClip;
	public AudioClip gameOverClip;
	public AudioClip uiClickClip;

	int bClip = 0;

	void Start () 
	{
		_audioSourceMain = GetComponent<AudioSource> ();
		RegisterEvents();

		bClip = UnityEngine.Random.Range(0, gameBgClip.Length);
	}

	void RegisterEvents()
	{
		onGameBgSoundPlay += GameBgSound;
		onGameBgUISoundPlay += GameBgUISound;
		onBgSoundStop += BgSoundStop;
		onGameOverSoundPlay += GameOverSound;
		onCollectSoundPlay += CollectSound;
	}

	public void GameBgUISound()
	{
		_audioSourceMain.volume = 0.3f;
		Background_clip(uiBgClip, true);
	}

	public void GameBgSound()
	{
		_audioSourceMain.volume = 0.6f;
		Background_clip(gameBgClip[bClip], true);
	}

	public void BgSoundStop()
	{
		_audioSourceMain.Stop();
	}

	public void GameOverSound()
	{
		PlayOneShot_clip(gameOverClip);
	}

	public void CollectSound()
	{
		PlayOneShot_clip(collectClip);
	}

	void Background_clip(AudioClip clip, bool isLoop)
	{
		if (clip == null)
			return;

		if (!_audioSourceMain.isPlaying && _audioSourceMain.clip.name != clip.name)
		{
			_audioSourceMain.clip = clip;
			_audioSourceMain.loop = isLoop;
			_audioSourceMain.Play();
		}
	}

	void PlayOneShot_clip(AudioClip clip)
	{
		if (clip == null)
			return;

		_audioSourceOnce.PlayOneShot (clip, 1);
		_audioSourceOnce.Play ();
	}
}