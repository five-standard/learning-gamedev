using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Item : MonoBehaviour
{
    [SerializeField] public float itemSpeed = 3.5f;
    
    //화면에 움직임 반영
    void Update () {
        moveControl(); }
    
    //화면 밖으로 나가면 삭제
    private void OnBecameInvisible() {
        Destroy(gameObject); }
    
    //이동 제어 (아래로 향함)
    void moveControl() {
        float distanceY = itemSpeed * Time.deltaTime;
        gameObject.transform.Translate(0, -1 * distanceY, 0); }
}
