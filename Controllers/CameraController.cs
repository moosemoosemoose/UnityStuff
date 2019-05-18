using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public _CharacterController playerCont;
    public float shakeAmount = 0.1f;
    public GameObject player;
    private Vector3 offset;
    public GameObject pauseCanvas;
    public GameObject gameOverCanvas;

    void Start()
    {
        offset = transform.position - player.transform.position;
        Time.timeScale = 1.0f;
    }

    void LateUpdate()
    {
        try
        {
            if (playerCont.getShakeStatus())
            {
                transform.position = player.transform.position + offset + Random.insideUnitSphere * shakeAmount;

            }
            else
            {
                transform.position = player.transform.position + offset;
            }
        }
        catch (MissingReferenceException)
        {
            //Time.timeScale = 0.0f;
            gameOverCanvas.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            pauseCanvas.SetActive(true);
        }
    }
    public void EndGame()
    {
        try
        {
            gameOverCanvas.SetActive(true);
        }
        catch (MissingReferenceException)
        {

        }
    }
}
