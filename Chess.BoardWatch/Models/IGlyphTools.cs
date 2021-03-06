﻿using AForge;
using AForge.Imaging;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Models
{
    public interface IGlyphTools
    {
        int MaxSize { get; set; }
        int MinSize { get; set; }
        int ThreshFilter { get; set; }
        float BlobSizeRatio { get; set; }
        float Minfullness { get; set; }
        int Glypdivisions { get; set; }
        ColorFilterSettings Black { get; set; }
        ColorFilterSettings Red { get; set; }
        ColorFilterSettings Blue { get; set; }
        ColorFilterSettings Green { get; set; }

        UnmanagedImage GrayImage { get; }
        UnmanagedImage BlackImage { get; }
        UnmanagedImage EdgeBlack { get; }
        UnmanagedImage threshBlack { get; }

        UnmanagedImage RImage { get; }
        UnmanagedImage GImage { get; }
        UnmanagedImage BImage { get; }

        UnmanagedImage edgeR { get; }
        UnmanagedImage edgeG { get; }
        UnmanagedImage edgeB { get; }

        UnmanagedImage threshR { get; }
        UnmanagedImage threshG { get; }
        UnmanagedImage threshB { get; }

        List<BlobData> Rblobs { get; }
        List<BlobData> Gblobs { get; }
        List<BlobData> Bblobs { get; }
        List<BlobData> BlackBlobs { get; }
        MasterCfg MasterCfg { set; }

        Task ProcessImage(Bitmap img);
        UnmanagedImage QuadralateralizeImage(UnmanagedImage img, List<IntPoint> corners, int newsize);
    }
}
