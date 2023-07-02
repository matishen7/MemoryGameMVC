﻿using MemoryGame;
using System;

public class HtmlBoardBuilder : IBoardBuilder
{
    private int m;
    private int n;
    private List<string> images = new List<string>() { };
    private List<int> imageAssignedCount = new List<int>() { };
    protected Board htmlBoard;

    public HtmlBoardBuilder()
    {
    }

    private void GetImages()
    {
        for (int i = 0; i < (m * n) / 2; i++)
        {
            var imageTitle = string.Format("image{0}", i);
            images.Add(imageTitle);
            imageAssignedCount.Add(0);
        }
    }

    private void SetImages()
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var imageTitle = PickRandomImage(images, imageAssignedCount);
                htmlBoard.cells[i][j].SetImage(imageTitle);
            }
        }
    }

    public IBoardBuilder WithDimensions(int m, int n)
    {
        this.m = m;
        this.n = n;
        GetImages();
        htmlBoard = new Board(m, n);
        return this;
    }

    public Board Build()
    {
        SetImages();
        return htmlBoard;
    }

    private T PickRandomImage<T>(List<T> list, List<int> assignedCount)
    {
        if (list == null || list.Count == 0)
        {
            throw new ArgumentException("The list must not be null or empty.");
        }

        int randomIndex = new Random().Next(0, list.Count - 1);
        var element = list[randomIndex];
        assignedCount[randomIndex]++;
        if (assignedCount[randomIndex] == 2)
        {
            list.RemoveAt(randomIndex);
            assignedCount.RemoveAt(randomIndex);
        };
        return element;
    }
}