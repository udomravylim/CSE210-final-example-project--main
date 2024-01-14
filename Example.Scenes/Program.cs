﻿using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Scenes.Title;


namespace Example.Scenes
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to create and move through different scenes.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the starting scene.
            Scene scene = new Scene();

            // Create the title scene loader and use it to set the starting scene.
            SceneLoader titleSceneLoader = new TitleSceneLoader(serviceFactory);
            titleSceneLoader.Load(scene);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
