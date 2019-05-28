using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public float pelletVelocity = 1;
    public GameObject pellet;
    public Transform GunEnd;
    List<Quaternion> pellets;

    // Start is called before the first frame update
    void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        int i = 0;
        foreach (Quaternion q in pellets.ToList())
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, GunEnd.position, GunEnd.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletVelocity);
            i++;
        }
    }
}
