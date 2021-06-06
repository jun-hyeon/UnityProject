using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Vector3 cursorPos;
    public GameObject btnX;

    private void OnMouseDown()
    {
        StartCoroutine("Wrong");
    }

    IEnumerator Wrong()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        GameObject temp = Instantiate(btnX, cursorPos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(temp);
    }
}
