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
        objectName = this.gameObject.name + "-1"; //objectname의 "-1"을 붙임
        m_SpriteRenderer.sprite = circle; //스프라이트 none 을 circle로 변환

        GameObject.Find("Hide");transform.Find(objectName).gameObject.SetActive(true); //Hide객체의 자식객체를 활성화
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
