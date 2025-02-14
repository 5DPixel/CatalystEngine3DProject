﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace $safeprojectname$.Graphics
{
    internal class ShaderProgram
    {
        public int ID;
        public ShaderProgram(string vertexShaderFilePath, string fragmentShaderFilePath) {
            ID = GL.CreateProgram();
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, LoadShaderSource(vertexShaderFilePath));
            GL.CompileShader(vertexShader);


            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, LoadShaderSource(fragmentShaderFilePath));
            GL.CompileShader(fragmentShader);

            GL.AttachShader(ID, vertexShader);
            GL.AttachShader(ID, fragmentShader);

            GL.LinkProgram(ID);


            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }

        public void Bind()
        {
            GL.UseProgram(ID);
        }

        public void Unbind()
        {
            GL.UseProgram(0);
        }

        public void Delete()
        {
            GL.DeleteShader(ID);
        }

        public static string LoadShaderSource(string filePath)
        {
            string source = "";

            try
            {
                using (StreamReader reader = new StreamReader($"../../../Shaders/{filePath}"))
                {
                    source = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to load shader source {e.Message}");
            }

            return source;
        }
    }
}
