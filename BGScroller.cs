using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float Speed = 2f;

    void FixedUpdate()
    {
        float scrollSpeed = Player.ScrollSpeed - Speed;
        this.transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
    }
}
