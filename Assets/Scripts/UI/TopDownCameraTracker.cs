using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraTracker : MonoBehaviour
{
    public GameObject target;
    public float speed = 1;
    public bool lerp;
    public float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LerpToTarget();
    }


    void LerpToTarget()
    {
        float lerpSpeed = lerp ? Time.deltaTime * speed : 1.0f;
        gameObject.transform.position = new Vector3
        {
            x = Mathf.Lerp(gameObject.transform.position.x, target.transform.position.x, lerpSpeed),
            y = target.transform.position.y + distanceToTarget,
            z = Mathf.Lerp(gameObject.transform.position.z, target.transform.position.z, lerpSpeed)
        };
    }
}
