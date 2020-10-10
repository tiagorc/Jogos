using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{

    public Vector3 startPosition;
    public Vector3 endPosition;
    public Transform startTransform;
    public Transform endTransform;
    public float speed = 0.5f;
    public bool changeSpriteX = false;
    public bool changeSpriteY = false;

    private SpriteRenderer spriteRenderer;
    private float mTime = 0.0f;
    private bool hasAnimator = false;
    void Start()
    {
        if (startTransform != null)
        {
            startPosition = startTransform.position;
        }

        if (endTransform != null)
        {
            endPosition = endTransform.position;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        hasAnimator = GetComponent<Animator>() != null;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAnimator) { return; }

        transform.position = Vector3.Lerp(startPosition, endPosition, mTime);
        mTime = Mathf.PingPong(Time.time * speed, 1.0f);

        if (mTime > 0.9f)
        {
            if (spriteRenderer == null) { return; }
            spriteRenderer.flipX = changeSpriteX;
            spriteRenderer.flipY = changeSpriteY;
        }
    }
}
