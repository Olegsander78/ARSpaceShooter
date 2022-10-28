using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float projectileSpeed;
    public float shootRate;
    private float lastShootTime;

    private Camera cam;

    public static Shooting instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Time.time - lastShootTime >= shootRate)
                Shoot();
        }
    }

    void Shoot()
    {
        lastShootTime = Time.time;

        GameObject proj = Instantiate(projectilePrefab, cam.transform.position, Quaternion.identity);

        proj.GetComponent<Rigidbody>().velocity = cam.transform.forward * projectileSpeed;
    }
}
