using UnityEngine;
using UnityEngine.SceneManagement;

public class G_BtnMng : MonoBehaviour
{
    //메인메뉴 - 시작 버튼
    public void StartButton() {
        SceneManager.LoadScene("ControlHelp"); }

    //메인메뉴 - 랭킹 화면
    public void RankingButton() {
        SceneManager.LoadScene("Ranking"); }
    
    //게임오버 - 재시작 버튼
    public void ReTryButton() {
        SceneManager.LoadScene("Ingame"); }

    //게임오버, 랭킹 - 메인메뉴 버튼 (Return 버튼)
    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu"); }
    
    //게임 종료 버튼
    public void ExitButton() {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit(); 
    #endif
    }
}