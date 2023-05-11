using TMPro;
using UnityEngine;

public class S_End : MonoBehaviour
{
    //스코어 텍스트 변수
    [SerializeField] private TextMeshProUGUI EndScoreText;
    
    //끝 화면에서 스코어 텍스트 수정
    void Start() {
        EndScoreText.text = "Level " + G_Score.level + " / Score : " + G_Score.score; }
}
