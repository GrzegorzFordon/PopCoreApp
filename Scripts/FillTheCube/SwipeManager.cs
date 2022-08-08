using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SwipeManager : MonoBehaviour
{
    bool isBusy;

    public GameObject pawnCube;
    public GameObject board;
    public float boardRotationSensitivity;

    void Update()
    {
        if (Inputs.pointerPress && !isBusy) StartCoroutine(OnPointerDown());
    }

    IEnumerator OnPointerDown()
    {
        isBusy = true;
        Vector2 startPos = Inputs.pointerPos;
        Vector2 dir = Vector2.zero;
        while (Inputs.pointerPress)
        {
            dir = (Inputs.pointerPos - startPos);
            board.transform.rotation = Quaternion.Euler(new Vector3(dir.y, -dir.x, 0) * boardRotationSensitivity);
            yield return new WaitForEndOfFrame();
        }
        Vector2 endPos = Inputs.pointerPos;
        // print(startPos + ", " + endPos + " || Dist: " + (endPos - startPos).normalized);

        EvaluateSwipe(dir);

        isBusy = false;
    }

    void EvaluateSwipe(Vector2 swipe)
    {
        if (swipe == Vector2.zero) return;

        Vector2 cleanDir = Vector2.zero;
        float xAbs = Mathf.Abs(swipe.x);
        float yAbs = Mathf.Abs(swipe.y);

        float xSign = Mathf.Sign(swipe.x);
        float ySign = Mathf.Sign(swipe.y);

        if (xAbs >= yAbs) cleanDir = xSign > 0 ? Vector2.right : Vector2.left;
        else cleanDir = ySign > 0 ? Vector2.up : Vector2.down;
        if (swipe.magnitude > 150) StartCoroutine(Move(cleanDir));
        else board.transform.DORotate(Vector3.zero, 0.2f);
    }

    IEnumerator Move(Vector2 dir)
    {
        Tween tween = board.transform.DORotate(Vector3.zero, 0.2f);
        yield return tween.WaitForCompletion();

        isBusy = true;
        RaycastHit hit;
        if (Physics.Raycast(pawnCube.transform.position, pawnCube.transform.TransformDirection(dir), out hit))
        {
            if (hit.transform.tag == "Goal")
            {
                Tween newtween = pawnCube.transform.DOLocalMove(hit.transform.localPosition, 0.75f);
                yield return newtween.WaitForCompletion();
            }
            else
            {
                Tween newtween = pawnCube.transform.DOShakeRotation(0.5f, 30);
                yield return newtween.WaitForCompletion();
            }
        }
        isBusy = false;
    }


}
