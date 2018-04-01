using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    Transform player;

    [SerializeField] float xDis, yDis;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;	
	}
	
	void Update ()
    {
        DrawBounds();
        if (!player) return;
        if (Mathf.Abs(player.position.x - transform.position.x) > xDis || Mathf.Abs(player.position.y - transform.position.y) > yDis) Follow();
	}

    void DrawBounds()
    {
        Debug.DrawLine(transform.position + (Vector3.up * (yDis)) + (Vector3.left * (xDis)) + (Vector3.forward * 5), transform.position + (Vector3.up * (yDis)) - (Vector3.left * (xDis)) + (Vector3.forward * 5));

        Debug.DrawLine(transform.position - (Vector3.up * (yDis)) + (Vector3.left * (xDis)) + (Vector3.forward * 5), transform.position - (Vector3.up * (yDis)) - (Vector3.left * (xDis)) + (Vector3.forward * 5));

        Debug.DrawLine(transform.position - (Vector3.up * (yDis)) + (Vector3.left * (xDis)) + (Vector3.forward * 5), transform.position + (Vector3.up * (yDis)) + (Vector3.left * (xDis)) + (Vector3.forward * 5));

        Debug.DrawLine(transform.position - (Vector3.up * (yDis)) - (Vector3.left * (xDis)) + (Vector3.forward * 5), transform.position + (Vector3.up * (yDis)) - (Vector3.left * (xDis)) + (Vector3.forward * 5));
    }

    void Follow()
    {
        transform.DOMove(player.position + (Vector3.forward * -10), 1.5f);

        
    }
}
