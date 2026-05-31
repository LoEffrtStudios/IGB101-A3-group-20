using UnityEngine;

public class SpinPickup : MonoBehaviour
{
    [Header("Rotation")]
    public Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);

    [Header("Bob Movement")]
    public float bobHeight = 0.25f;
    public float bobSpeed = 2f;

    [Header("Pickup Settings")]
    public AudioClip pickupSound;
    public float soundVolume = 1f;

    private float startY;
    private GameManager gameManager;
    private AudioSource audioSource;

    void Start()
    {
        // Cache starting Y position for bobbing
        startY = transform.localPosition.y;

        // Find GameManager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        // Create an AudioSource if none exists
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Spin
        transform.Rotate(rotationSpeed * Time.deltaTime);

        // Bob
        float newY = startY + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment pickup count
            gameManager.currentPickups += 1;

            // Play sound (if assigned)
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position, soundVolume);

            // Destroy pickup object
            Destroy(gameObject);
        }
    }
}
