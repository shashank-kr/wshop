﻿using EventFlow.Core;

namespace WShop.MarsRover.Core.Domain.ValueTypes
{
    public class Identity : Identity<Identity>
    {
        public Identity(string value)
         : base(value)
        {
        }
    }
}
