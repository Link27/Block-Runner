using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSound : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public static AudioClip jumpSound, crashSound;
    static AudioSource audioSrc;

    void Start ()
    {
        jumpSound = Resources.Load<AudioClip>("Pop");
        crashSound = Resources.Load<AudioClip>("Thump");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = player.position + offset;
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "crash":
                audioSrc.PlayOneShot(crashSound);
                break;
        }
    }
}
