using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace Tests
{
    public class SceneTests
    {
        public static string scene1 = "SinglePlayerScene";
        public static string scene2 = "LobbyJoinScene";
        public static string scene3 = "SettingsScene";

        [Test]
        public void scene1Test()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/SinglePlayerScene.unity");
            string activeScene1 = EditorSceneManager.GetActiveScene().name;
            Assert.AreEqual(activeScene1, scene1);
        }

        [Test]
        public void scene2Test()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/LobbyJoinScene.unity");
            string activeScene2 = EditorSceneManager.GetActiveScene().name;
            Assert.AreEqual(activeScene2, scene2);
        }

        [Test]
        public void scene3Test()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/SettingsScene.unity");
            string activeScene3 = EditorSceneManager.GetActiveScene().name;
            Assert.AreEqual(activeScene3, scene3);
        }
    }
}
