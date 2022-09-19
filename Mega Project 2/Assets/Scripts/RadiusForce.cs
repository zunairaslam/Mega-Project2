using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusForce : MonoBehaviour
{
    public Rigidbody forceRb;
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        forceRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (other.CompareTag("Enemy"))
            {
                Vector3 pushBack = other.transform.position - transform.position;
                other.GetComponent<Rigidbody>().AddForce(pushBack * speed, ForceMode.Impulse);
                Debug.Log("hello");
            }

        }
        
    }
}
