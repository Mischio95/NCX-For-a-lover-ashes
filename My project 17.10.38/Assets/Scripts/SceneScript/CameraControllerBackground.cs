using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBackground : MonoBehaviour
{ 
    public Transform player;
    public Transform activeRoom;
    public float dampSpeed;

    public static CameraControllerBackground instance;

    [Range(5, -5)] public float minModX, maxModX, minModY, maxModY; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {

        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

        Vector3 clampedPos = new Vector3(
        Mathf.Clamp(player.position.x, minPosX, maxPosX),
        Mathf.Clamp(player.position.y, minPosY, maxPosY),
        Mathf.Clamp(player.position.z, -10f, -10f)
        );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
