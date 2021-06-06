using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickevent : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer m_SpriteRenderer;
    private Sprite circle;
    string objectName;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        circle = Resources.Load<Sprite>("circle");
    }

    private void OnMouseDown()
    {
        objectName = this.gameObject.name + "-1"; //objectname�� "-1"�� ����
        m_SpriteRenderer.sprite = circle; //��������Ʈ none �� circle�� ��ȯ

        GameObject.Find("Hide");transform.Find(objectName).gameObject.SetActive(true); //Hide��ü�� �ڽİ�ü�� Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
