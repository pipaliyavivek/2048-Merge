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

    /*private void Update()
    { 
        if (transform.position.y < -2)
        {
            Destroy(gameObject); GameManager.instance.CubeAvailable = false;
        }
    }*/
    void Awake()
    {
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
    }
}

