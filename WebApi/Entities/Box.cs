﻿namespace WebApi.Entities;

public class Box
{
    public int Id { get; set; }
    public string Label { get; set; }
    public Dimensions Dimensions { get; set; }
    public Box(int id, string label, Dimensions dimensions)
    {
        Id = id;
        Label = label;
        Dimensions = dimensions;
    }
}