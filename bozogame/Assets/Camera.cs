using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    public float speed = 0.09f;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = player.position;
        Vector2 current = transform.position;

        var calculated = Vector2.Lerp(current, target, speed * Time.deltaTime);

        transform.position = new Vector3(calculated.x, calculated.y, -10);

    }
}
