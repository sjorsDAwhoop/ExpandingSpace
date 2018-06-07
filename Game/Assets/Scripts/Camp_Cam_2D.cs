using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Camp_Cam_2D : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float xMin = -1;
    [SerializeField] float xMax = 1;
    [SerializeField] float yMin = -1;
    [SerializeField] float yMax = 1;
    [SerializeField] float speed = 1;
    [SerializeField] float centerOffsetX = 1;
    [SerializeField] float centerOffsetY = 1;

    Transform t;
    SpriteRenderer spriteRendererTarget;

    private void Awake()
    {
        t = transform;
        spriteRendererTarget = target.GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        float flipValueX = spriteRendererTarget.flipX ? 1 : -1;
        float flipValueY = spriteRendererTarget.flipY ? 1 : -1;
        float x = Mathf.Clamp(target.position.x + (target.transform.right.x * flipValueX * centerOffsetX), xMin, xMax);
        float y = Mathf.Clamp(target.position.y + (target.transform.up.y * flipValueY * centerOffsetY), yMin, yMax);

        t.position = Vector3.Lerp(t.position, new Vector3(x, y, t.position.z), speed * Time.deltaTime);
    }
}