using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempdeadanimation : MonoBehaviour
{
    bool died = false;
    // Start is called before the first frame update
    void Start()
    {
        died = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        if(!died)
        {
            died = true;
            foreach(Transform child in this.transform)
            {
                Component rb = child.gameObject.AddComponent(typeof(Rigidbody));
                ((Rigidbody)rb).useGravity = true;
                ((Rigidbody)rb).mass = 0.1f;
                ((Rigidbody)rb).AddForce(new Vector3(Random.Range(-3, 3) * 3, Random.Range(-3, 3) * 3, Random.Range(-3, 3) * 3));
            }
        }
    }
}
