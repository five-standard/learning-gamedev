using UnityEngine;

public class E_Enemy : MonoBehaviour
{
    //화면에 움직임 반영
    void Update () {
        moveControl(); }
    
    //화면 밖으로 나가면 삭제
    private void OnBecameInvisible() {
        Destroy(gameObject); }
    
    //이동 제어 (아래로 향함)
    void moveControl() {
        float distanceY = G_VMng.enemySpeed * Time.deltaTime;
        gameObject.transform.Translate(0, -1 * distanceY, 0); }
}
