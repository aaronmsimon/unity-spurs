using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), step);
    }
}
