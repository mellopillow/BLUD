using UnityEngine;

[ExecuteInEditMode]
public class ShaderBonny : MonoBehaviour
{
    public Material Mat;

    void Start()
    {
        //Cursor.visible = false;
    }


    public void Update()
    {
        Vector3 bonnyPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Shader.Find(Spotlight);
        Debug.Log(Mat.shader);
        Debug.Log("Hello?");

        float xPos = bonnyPos.x / Screen.width * 0.5f;
        float yPos = bonnyPos.y / Screen.height * (0.5f * 9) / 16;
        Mat.SetFloat(Shader.PropertyToID("_CenterX"), xPos);
        Mat.SetFloat(Shader.PropertyToID("_CenterY"), yPos);
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}
