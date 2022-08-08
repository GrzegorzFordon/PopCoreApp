using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    public GameObject sprite;
    public float distTresh;
    public Vector3 lastPos;
    public Transform paintParent;

    private void Awake()
    {
        SpawnSprite();
    }
    private void Update()
    {
        print(transform.localPosition);
        if (Vector3.Distance(transform.localPosition, lastPos) >= distTresh)
            SpawnSprite();
    }

    void SpawnSprite()
    {
        lastPos = transform.localPosition;
        GameObject newPaintSprite = Instantiate(sprite, transform.localPosition, transform.localRotation);
        newPaintSprite.transform.SetParent(paintParent);
        newPaintSprite.transform.localPosition = new Vector3(newPaintSprite.transform.localPosition.x, newPaintSprite.transform.localPosition.y, 0);
    }
}
