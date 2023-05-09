using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class G_Score : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI Scoretext;
    [SerializeField] private TextMeshProUGUI Leveltext;
    [SerializeField] public int level = 1;
    public static float maxscore = 100;
    public static int scoreToAdd = 10;
    public static float score = 0; 
    public static G_Score instance;
    
    //자기 자신을 참조
    void Awake() {
        if (!instance)
            instance = this; }
    
    //점수 값 설정 (텍스트 설정)
    private void Start() {
        score = 0;
        level = 1;
        Scoretext.text = "0 Score";
        Leveltext.text = "1 Level"; }

    //점수 추가 함수
    public void addscore(int num) {
        if (E_Boss.BossSpawned == false) {
            score += num;
            Scoretext.text = score + " Score";
            if (score >= maxscore) {
                E_Boss.E_Boss2.SpawnBoss(); } } }
}
