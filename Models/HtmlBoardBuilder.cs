using MemoryGame;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


public class HtmlBoardBuilder : IBoardBuilder
{
    private int m;
    private int n;
    private List<string> images = new List<string>() { };
    private List<int> imageAssignedCount = new List<int>() { };
    protected Board htmlBoard;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HtmlBoardBuilder(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    private void GetImages()
    {
        var folderPath = "/images/cards/";
        string rootPath = _webHostEnvironment.ContentRootPath;
        string[] cards = System.IO.Directory.GetFiles(rootPath + folderPath);
        for (int i = 0; i < (m * n) / 2; i++)
        {
            var card = cards[i].Split('\\');
            var nameOfCard = card[card.Length - 1];
            images.Add(nameOfCard);
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