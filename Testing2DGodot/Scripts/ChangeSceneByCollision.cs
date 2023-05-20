using Godot;
using System;

public partial class ChangeSceneByCollision : Area2D
{
    
    [Export]
    public string SceneToLoad; // Ruta de la escena a la que deseas cambiar

    public override void _Ready()
    {
        BodyEntered += OnAreaEntered;
    }

    public void OnAreaEntered(Node2D area)
    {
        if (area.Name.Equals("Player")) // Reemplaza "Player" con el nombre del nodo que genera la colision
        {
           PackedScene newScene = (PackedScene)GD.Load(SceneToLoad);
            Node newSceneInstance = newScene.Instantiate();
            Node currentScene = GetTree().CurrentScene;

            currentScene.GetParent().AddChild(newSceneInstance);
            currentScene.QueueFree();
        }
    }
}

    
