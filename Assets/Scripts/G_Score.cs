using TMPro;
using UnityEngine;

public class G_Score : MonoBehaviour
{
    //인게임 점수 텍스트
    [SerializeField] private TextMeshProUGUI Scoretext;
    
    //자기 자신을 참조 (검사)
    void Awake() {
        if (!G_VMng.instance)
            G_VMng.instance = this; }
    
    //점수 값 설정 (텍스트 설정)
    private void Start() {
        G_VMng.score = 0;
        Scoretext.text = "0 Score"; }
    
    //점수 추가 함수
    public void addscore(int num) {
        G_VMng.score += num;
        Scoretext.text = G_VMng.score + " Score"; }
    
    //점수 차감 함수
    public void remscore(int num) {
        G_VMng.score -= num;
        Scoretext.text = G_VMng.score + " Score"; }
}
