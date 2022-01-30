using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPost;


    // Start is called before the first frame update
    void Start()
    {
        nextPost = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPost = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPost = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPost, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}