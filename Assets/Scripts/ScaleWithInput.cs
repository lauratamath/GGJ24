using System.Collections;
using UnityEngine;

public class ScaleWithInput : MonoBehaviour
{
    public AudioInputDetection detector;
    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    // Jump vars
    public float jumpForce = 10f;
    public float jumpThreshold = 500f;
    private bool isJumping = false;

    // Increase velocity 
    private float noiseStartTime;
    public float timeThreshold = 3f;
    public float speedIncrement = 2f;
    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        noiseStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        // Check sound frequency to jump
        if (loudness > jumpThreshold && !isJumping)
        {
            Jump();
        }

        // If the sound last more than # second, it increases speed
        if (loudness > threshold)
        {
            if (Time.time - noiseStartTime > timeThreshold)
            {
                IncreaseSpeed();
            }
        }
        else
        {
            noiseStartTime = Time.time; // If there is no noise, reset the time
        }

        // move the object with actual speed
        Vector3 moveDirection = new Vector3(loudness, 0f, 0f);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // Aplicar fuerza vertical al objeto para brincar
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
        StartCoroutine(ResetJumpFlag());
    }

    void IncreaseSpeed()
    {
        // Incrementar la velocidad del objeto
        moveSpeed += speedIncrement;
        noiseStartTime = Time.time; // Reiniciar el tiempo después de incrementar la velocidad
    }

    IEnumerator ResetJumpFlag()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta según sea necesario
        isJumping = false;
    }
}
