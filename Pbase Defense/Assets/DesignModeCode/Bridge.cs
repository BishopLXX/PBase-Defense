using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {
    void Start()
    {
        Sphere sphere = new Sphere();
        sphere.Draw();
        Cube cube = new Cube();
        cube.Draw();
    }
}

public class Sphere
{
    public string name = "Sphere";

    public OpenGL openGL = new OpenGL();

    public void Draw()
    {
        openGL.Render(name);
    }
}

public class Cube
{
    public string name = "Cube";

    public OpenGL openGL = new OpenGL();

    public void Draw()
    {
        openGL.Render(name);
    }
}

public class OpenGL
{
    public void Render(string name)
    {
        Debug.Log("绘制: " + name);
    }
}
