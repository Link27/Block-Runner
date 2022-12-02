using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    public Rigidbody rb;

    void FixedUpdate()
    {
        rb.transform.Rotate(.4f, .2f, -.8f);
    }
}
