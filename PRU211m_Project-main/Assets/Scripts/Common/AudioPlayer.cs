using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("MenuSounds")]
    [SerializeField] AudioClip clickSound;
    [SerializeField] [Range(0f, 1f)] float volume = 0.5f;
    [SerializeField] AudioClip openingSound;

    public void PlayClickingSound()
    {
        if(clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, volume);
        }
    }
}
