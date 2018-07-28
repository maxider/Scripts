using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    
    public Transform FloorSegments;
    public Transform Pipes;
    public Transform BgImgs;

    Transform lastSegment;
    Transform lastPipe;

    float nextXPos;
    float nextPipePos;
    float nextBgPos;

    float pipeOffset = 7f;
    public float MinPipe = -5f;
    public float MaxPipe = 5f;

    public void Start()
    {
        lastSegment = FloorSegments.GetChild(FloorSegments.childCount - 1);
        nextXPos = lastSegment.position.x + lastSegment.GetComponent<BoxCollider2D>().size.x * lastSegment.transform.localScale.x;

        lastPipe = Pipes.GetChild(Pipes.childCount - 1);
        nextPipePos = lastPipe.position.x + pipeOffset;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Floor"))      spawnNextFloorSegment(collision);
        if (collision.name.Contains("Pipe"))       spawnNextPipe(collision);
        if (collision.name.Contains("Background")) moveBg(collision);
    }

    void spawnNextFloorSegment(Collider2D collision)
    {
        Vector2 nextPos = new Vector2(nextXPos, lastSegment.position.y);
        collision.transform.position = nextPos;
        nextXPos += lastSegment.GetComponent<BoxCollider2D>().size.x * lastSegment.transform.localScale.x;
    }

    void spawnNextPipe(Collider2D collision)
    {
        float nextY = Random.Range(MinPipe, MaxPipe);

        Vector2 nextPos = new Vector2(nextPipePos, nextY);
        collision.transform.position = nextPos;
        nextPipePos += pipeOffset;
    }

    void moveBg(Collider2D collision)
    {
        float width = collision.transform.localScale.x;
        Vector3 pos = collision.transform.position;
        pos.x += ((width * 1280) / 100)*3;
        collision.transform.position = pos;
        Debug.Log("BG moved");

    }
}
