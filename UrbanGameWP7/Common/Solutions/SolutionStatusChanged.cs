﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SolutionStatusChanged
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public SolutionStatus Status { get; set; }
    }
}