using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour {

    [SerializeField]private AudioClip[] clips;
    [SerializeField]private Sprite[] soundSprites;
    [SerializeField]private Image soundSprite;
    private AudioSource source;
    private bool soundIsOn = true;

	// Use this for initialization
	void Awake () {
        source = GetComponent<AudioSource>();
	}
	
    public void PlaySound(int clipNumber)
    {
        source.clip = clips[clipNumber];
        source.PlayOneShot(source.clip);
    }

    public void ToggleSound()
    {
        soundIsOn = !soundIsOn;
        if(soundIsOn)
        {
            AudioListener.volume = 1;
            soundSprite.sprite = soundSprites[0];
        }
        else
        {
            AudioListener.volume = 0;
            soundSprite.sprite = soundSprites[1];
        }
        
    }
}
