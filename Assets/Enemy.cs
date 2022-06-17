using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touché");
        if (collision.collider.TryGetComponent(typeof(Assets.Scripts.Business.Bullet), out _))
            GetComponentInChildren<tempdeadanimation>(true).Die();
    }
}
