using UnityEngine;

public class E_Bullet : MonoBehaviour
{
    //화면 밖으로 나가면 삭제
    private void OnBecameInvisible() {
        Destroy(gameObject); }

    //적하고 닿으면 적과 자기 자신 제거
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag.Equals("Enemy")) {
            Destroy(col.gameObject);
            Destroy(gameObject);
            G_VMng.instance.addscore(100); } }
}
