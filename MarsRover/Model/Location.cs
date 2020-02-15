using MarsRover.Helper;
using System;
using System.ComponentModel;

namespace MarsRover.Model
{
    public class Location
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public eDirection CurrentDirection { get; set; }

        public override string ToString() => $"{XPosition} {YPosition} {Utility.GetDescriptionFromEnumValue(CurrentDirection)}";
    }

    public enum eDirection
    {
        [Description("West")]
        W ,
        [Description("East")]
        E,
        [Description("North")]
        N,
        [Description("South")]
        S
    }
}