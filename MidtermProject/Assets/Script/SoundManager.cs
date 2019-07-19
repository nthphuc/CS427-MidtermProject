using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerShootSound, collectGemSound, victorySound, dieSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerShootSound = Resources.Load<AudioClip>("ShootSound");
        collectGemSound = Resources.Load<AudioClip>("CollectGemSound");
        victorySound = Resources.Load<AudioClip>("VictorySound");
        dieSound = Resources.Load<AudioClip>("DieSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "ShootSound":
                audioSrc.PlayOneShot(playerShootSound);
                break;
            case "CollectGemSound":
                audioSrc.PlayOneShot(collectGemSound);
                break;
            case "VictorySound":
                audioSrc.PlayOneShot(victorySound);
                break;
            case "DieSound":
                audioSrc.PlayOneShot(dieSound);
                break;
        }
    }
}
