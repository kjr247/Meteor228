using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset;
    public float cameraMoveSpeed = 0.0f;
    public float cameraMovementSensitivity = 0.2f;
    public float timer = 0.0f;

    // Update is called once per frame
    void LastUpdate()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        timer = timer + Time.deltaTime;
        if (timer >= cameraMovementSensitivity)
        {
            timer = 0.0f;
            Vector3 lookAtTargetPostition = new Vector3(
                player.transform.position.x,
                this.transform.position.y,
                player.transform.position.z
            );
            Vector3 followTargetPostition = player.transform.position + cameraOffset;
            this.transform.LookAt(followTargetPostition);
        }
    }
}
