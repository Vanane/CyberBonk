using Assets.Scripts.Business.Items;
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
        public BulletItem bulletItem;

        public Rigidbody body;
        

        virtual public void Shoot(float speed, float decayTime, float offAngle = 0.0f)
        {
               Vector3 direction = transform.forward;
            float offsetAngle = UnityEngine.Random.Range(-offAngle / 2.0f, offAngle / 2.0f);
            direction = Quaternion.Euler(0, offsetAngle, 0) * direction;
            body.AddForce(direction * speed);
            Invoke("DestroyBullet", decayTime);
        }


        private void DestroyBullet()
        {
            Destroy(this.gameObject);
        }
    }
}
