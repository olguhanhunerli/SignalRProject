﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.AboutDto
{
    public class UpdateAboutDto
    {
        public int AboutId { get; set; }
        public string AboutImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
