using UnityEngine;

public class DoorTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animation animation;
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
                animation.Play();
        
    }
}
