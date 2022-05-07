using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float scrollSpeed;

    private void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime / scrollSpeed;

        mat.mainTextureOffset = offset;
    }
}
