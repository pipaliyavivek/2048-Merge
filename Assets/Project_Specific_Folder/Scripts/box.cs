using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class box : MonoBehaviour
{
    TextMeshPro[] T_text, P_text;
    public int value;
    public int[] values = new int[] { 2, 4, 8 };

    public GameObject m_Shodow;
    public Vector3 Cubeposition;
    public MeshRenderer m_Mesh;

    /*private void Update()
    { 
        if (transform.position.y < -2)
        {
            Destroy(gameObject); GameManager.instance.CubeAvailable = false;
        }
    }*/
    void Awake()
    {
        m_Mesh = GetComponent<MeshRenderer>();
        value = values[Random.Range(0, values.Length - 1)];
        changetext();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube" && value == collision.gameObject.GetComponent<box>().value)
        {
            value *= 2;
            changetext();
            GetComponent<Rigidbody>().AddForce(Vector3.up * 300, ForceMode.Force);
            Destroy(collision.gameObject);
        }
    }
    void changetext()
    {
        T_text = GetComponentsInChildren<TextMeshPro>();
        gameObject.name = value.ToString();
        for (int i = 0; i < T_text.Length; i++)
        {
            T_text[i].text = value.ToString();
        }
        switch (value)
        {
            case 2:
                m_Mesh.material.color = GameManager.instance.m_CubesColor[0];
                break;
            case 4:
                m_Mesh.material.color = GameManager.instance.m_CubesColor[1];
                break;
            case 8:
                m_Mesh.material.color = GameManager.instance.m_CubesColor[2];
                break; 
            case 16:
                m_Mesh.material.color = GameManager.instance.m_CubesColor[3];
                break;
            case 32:
                m_Mesh.material.color = GameManager.instance.m_CubesColor[4];
                break;
            case 64:
                m_Mesh.material.color = GameManager.instance.m_CubesColor[5];
                break;
            case 128:
                m_Mesh.material.color = GameManager.instance.m_CubesColor[6];
                break;
        }
    }
}

