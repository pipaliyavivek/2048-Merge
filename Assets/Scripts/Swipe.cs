/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
   
    public GameObject player;
    Rigidbody rb;
    Vector3 m_PreviousPosition;
    float m_dummyfloat;
    float m_MinimumDrag;
    float MoveSensitivity = 5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }
    private void Update()
    {
        if (transform.position.z < -5.5)
        {

            if (Input.GetMouseButtonDown(0))
            {
                m_PreviousPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                m_PreviousPosition = Vector3.zero;
            }
            else if (Input.GetMouseButton(0) && m_PreviousPosition != Vector3.zero)
            {

                m_dummyfloat = Input.mousePosition.x - m_PreviousPosition.x;

                if (m_MinimumDrag < Mathf.Abs(m_dummyfloat))
                {
                    m_dummyfloat /= 100;
                    m_dummyfloat *= MoveSensitivity;
                    Vector3 localTargetPosition = transform.position;
                    localTargetPosition.x += m_dummyfloat;
                    localTargetPosition.x = Mathf.Clamp(localTargetPosition.x, -3, 3);
                    player.transform.localPosition = localTargetPosition;
                }
                m_PreviousPosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                rb.AddForce(transform.forward * 1000);
                GameManager.instance.CubeAvailable = false;

            }            
        }
    }    
}

*/