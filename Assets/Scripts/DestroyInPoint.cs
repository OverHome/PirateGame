using System;
using System.Runtime.CompilerServices;
using UnityEngine;


public class DestroyInPoint : MonoBehaviour
{
        [SerializeField] private Transform _transform;

        private bool IsUse;

        private void Start()
        {
                IsUse = false;
        }

        private void Update()
        {
                if (!IsUse)
                {
                        if (transform.position.x == _transform.position.x)
                        {
                                gameObject.SetActive(false);
                                IsUse = true;
                        }      
                }
        }
}
