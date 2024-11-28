using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMoreButton : MonoBehaviour
{
    public RectTransform moreButton;
    public RectTransform butt1;
    public RectTransform butt2;
    public RectTransform butt3;
    public float moveSpeed = 50f;
    private bool isMoving = false;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        // Save the initial position of the UI icon
        startPosition = moreButton.anchoredPosition;
        // Calculate the target position by moving -200 in the X direction
        targetPosition = new Vector3(startPosition.x - 110f, startPosition.y, startPosition.z);
    }

    private void Update()
    {

    }

    public void moreOnClicked()
    {
        isMoving = !isMoving;

        // Start or stop the movement coroutine
        if (isMoving)
        {
            StartCoroutine(MoveIcon(targetPosition));
        }
        else
        {
            StartCoroutine(MoveIcon(startPosition));
        }
    }

    // Coroutine to smoothly move the UI icon to the target position
    private IEnumerator MoveIcon(Vector3 target)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            // Interpolate between the current position and the target position
            moreButton.anchoredPosition = Vector3.Lerp(moreButton.anchoredPosition, target, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;

            yield return null;
        }

        // Ensure the icon reaches the exact target position
        moreButton.anchoredPosition = target;
    }
}

