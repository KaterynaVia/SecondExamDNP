﻿namespace WebApi.Entities;

public class Dimensions
{
    
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public Dimensions(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
}