using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow_on_fire : MonoBehaviour
{

        public float growthAmount = 0.1f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Fire"))
            {
                transform.localScale += new Vector3(growthAmount, growthAmount, growthAmount);
            }
        }
}
