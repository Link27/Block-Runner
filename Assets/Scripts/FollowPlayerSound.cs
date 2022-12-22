using UnityEngine;

public class FollowPlayerSound : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public static AudioClip jumpSound, crashSound;
    static AudioSource audioSrc;

    void Start ()
    {
        // Loads the in game sounds from the Resources folder
        jumpSound = Resources.Load<AudioClip>("Pop");
        crashSound = Resources.Load<AudioClip>("Thump");

        // Kind of don't know what this technically does either?
        audioSrc = GetComponent<AudioSource>();
    }

    // Sound follows the player just like the camera
    void Update()
    {
        transform.position = player.position + offset;
    }

    public static void PlaySound(string clip)
    {
        // Depending on what is pressed and passed, this will determine what sound will be played
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
