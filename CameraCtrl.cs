using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649
namespace UnityStandardAssets.Utility {

    public class CameraCtrl : MonoBehaviour
    {

        
        Transform playerTransform;
        Vector3 Offset;
        private void Awake()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Offset = transform.position - playerTransform.position;
        }

        

            // Update is called once per frame
            void LateUpdate()
        {
            transform.position = playerTransform.position + Offset;

        }

      

    }
}
