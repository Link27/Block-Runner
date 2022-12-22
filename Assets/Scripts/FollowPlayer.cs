using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;

    // Forces the camera to follow the player with an offset
    void Update()
    {
        transform.position = player.position + offset;
    }
}
