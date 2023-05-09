using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Control : MonoBehaviour
{
    //컨트롤 도움말 화면에서 스페이스바로 씬 변경
    void Update() {
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetKey(KeyCode.Space)) {
            if (scene.name == "ControlHelp") {
                SceneManager.LoadScene("Ingame"); } } }
}
