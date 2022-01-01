using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject splayer;
    public bool CubeAvailable ;
    public GameObject cube;

    public GameObject player;
  
    Vector3 m_PreviousPosition;
    float m_dummyfloat;
    float m_MinimumDrag;
    float MoveSensitivity = 5f;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                 cube = Instantiate(splayer, transform.position, Quaternion.identity);
                //p.transform.position = transform.position;
                 CubeAvailable = true;
                 m_PreviousPosition = Input.mousePosition;
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
                if (cube!=null)
                {
                    cube.transform.localPosition = localTargetPosition;
                }
                }
                m_PreviousPosition = Input.mousePosition;
            }
        else if (Input.GetMouseButtonUp(0))
        {
            m_PreviousPosition = Vector3.zero;
            cube.GetComponent<Rigidbody>().AddForce(cube.transform.forward * 1000);           
            CubeAvailable = false;
        }
        /*}*/
    }
   
}
