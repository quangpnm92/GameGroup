using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPos;

    private float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(arrow, arrowPos.position, Quaternion.identity);
    }
}
