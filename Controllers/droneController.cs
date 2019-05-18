using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float orbitDistance = 3.0f;
    public float orbitDegrees = 90.0f;
    public Vector3 relativeDistance = Vector3.zero;
    private LineRenderer laserLine;
    public Transform gunEnd;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    public Camera cam;
    public float weaponRange;


    void Start()
    {
        
        if (player != null)
        {
            relativeDistance = transform.position - player.transform.position;
        }
        laserLine = GetComponent<LineRenderer>();
    }


    void LateUpdate()
    {
        
        Orbit();
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Pew");
            StartCoroutine(Shoot());
            laserLine.SetPosition(0, gunEnd.position);
            
        }
    }

    void Orbit()
    {
        if (player != null)
        {
            transform.position = player.transform.position + relativeDistance;

            transform.RotateAround(player.transform.position, Vector3.up, orbitDegrees * Time.deltaTime);
            relativeDistance = transform.position - player.transform.position;
        }
    }

    private IEnumerator Shoot()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
