﻿namespace SimpleFactory
{
    using System;

    using Fans;
    using Fans.Contracts;

    public class FanFactory : IFanFactory
    {
        public IFan CreateFan(FanType type)
        {
            switch (type)
            {
                case FanType.TableFan:
                    return new TableFan();
                case FanType.CeilingFan:
                    return new CeilingFan();
                default:
                    throw new ArgumentException();
            }
        }
    }
}