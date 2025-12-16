using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float laneDistance = 2.5f;
    public float jumpForce = 6f;

    private int currentLane = 1; // 0 = gauche, 1 = centre, 2 = droite
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Avancer tout seul
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Changer de lane
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeLane(-1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeLane(1);

        // Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void ChangeLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
        Vector3 targetPos = transform.position;
        targetPos.x = (currentLane - 1) * laneDistance;
        transform.position = targetPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

}

