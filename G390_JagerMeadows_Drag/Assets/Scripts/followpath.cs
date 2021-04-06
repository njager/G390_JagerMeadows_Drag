using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followpath : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public float damping = 6.0f;

    private int current;
    
    void Update()
    {
        if (transform.position != target[current].position)
        {
            var rotation = Quaternion.LookRotation(target[current].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % target.Length;
    }
}
