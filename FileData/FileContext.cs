﻿using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;



    public ICollection<Alien> Aliens
    {
        get
        {
            LoadData();
            return dataContainer!.Aliens;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;
        
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                
                Aliens = new List<Alien>()
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}