using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    private const string extension = ".json";
    
    public JObject LoadJsonFromFile(string saveFile)
    {
        string path = GetPathFromSaveFile(saveFile);
        if (!File.Exists(path))
        {
            return new JObject();
        }
            
        using (var textReader = File.OpenText(path))
        {
            using (var reader = new JsonTextReader(textReader))
            {
                reader.FloatParseHandling = FloatParseHandling.Double;
                return JObject.Load(reader);
            }
        }

    }

    
    public void SaveFileAsJSon(string saveFile, JObject state)
    {
        string path = GetPathFromSaveFile(saveFile);
        print("Saving to " + path);
        using (var textWriter = File.CreateText(path))
        {
            using (var writer = new JsonTextWriter(textWriter))
            {
                writer.Formatting = Formatting.Indented;
                state.WriteTo(writer);
            }
        }
    }

    
    private string GetPathFromSaveFile(string saveFile)
    {
        return Path.Combine(Application.persistentDataPath, saveFile + extension);
    }

    
}
