using UnityEngine;

/*
 * Adds rotation to the door marker
 */
public class MarkerController : MonoBehaviour
{

    private float rotationSpeed = 50f;
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
