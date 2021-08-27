using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Business
{
    public class Bullet : MonoBehaviour
    {
        public float speed;
        public float decayTime;
        public Rigidbody body;
        

        private void Start()
        {
            Invoke("DestroyBullet", decayTime);
        }


        private void DestroyBullet()
        {
            Destroy(this.gameObject);
        }
    }
}
