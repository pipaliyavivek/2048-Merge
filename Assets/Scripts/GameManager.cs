using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject splayer;
    public bool CubeAvailable;
    public GameObject cube;

    public GameObject player;

    //private Vector3 localTargetPosition;
    Vector3 m_PreviousPosition;
    float m_dummyfloat;
    float m_MinimumDrag;
    float MoveSensitivity = 20f;

    private bool isfirstimel;
    private void Awake()
    {
        //localTargetPosition = transform.position;
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
            var po = Input.mousePosition.x - m_PreviousPosition.x;
            var canpos = cube.transform.localPosition;
            var df = po / MoveSensitivity;
            canpos.x = Mathf.Clamp(df, -3, 3);
            cube.transform.localPosition = canpos;
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
