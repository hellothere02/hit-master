using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("44");
            Rigidbody[] rb = other.gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (var item in rb)
            {
                item.isKinematic = false;
            }
            other.GetComponent<Animator>().enabled = false;
            other.gameObject.tag = "dead";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
