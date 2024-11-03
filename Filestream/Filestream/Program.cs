using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public class NameManager
{
    private List<string> _names;
    private const string FilePath = "names.json";

    public NameManager()
    {
        _names = new List<string>();
        LoadNamesFromFile();
    }

    private void LoadNamesFromFile()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            _names = JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
        }
    }

    private void SaveNamesToFile()
    {
        string json = JsonConvert.SerializeObject(_names);
        File.WriteAllText(FilePath, json);
    }

    public void Add(string name)
    {
        if (!Exist(name))
        {
            _names.Add(name);
            SaveNamesToFile();
        }
    }

    public bool Exist(string name)
    {
        return _names.Contains(name);
    }

    public void Update(int index, string name)
    {
        if (index >= 0 && index < _names.Count)
        {
            _names[index] = name;
            SaveNamesToFile();
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    public void Delete(int index)
    {
        if (index >= 0 && index < _names.Count)
        {
            _names.RemoveAt(index);
            SaveNamesToFile();
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
}
