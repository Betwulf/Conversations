﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.Interfaces;

namespace ConversationsCore.DataObjects
{
    public class ResponseFile : IRepositoryObject
    {
        public string Id { get; set; }

        public string WaveFilename { get; set; }


    }
}
