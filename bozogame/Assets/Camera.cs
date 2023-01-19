using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = player.position;
        Vector2 current = transform.position;

        var calculated = Vector2.Lerp(current, target, 0.15f * Time.deltaTime);

        transform.position = new Vector3(calculated.x, calculated.y, -10);

    }
}
