using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            collision.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
