using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversationsCore.Interfaces;

namespace ConversationsCore.DataObjects
{
    public class Response : IRepositoryObject
    {

        /// <summary>
        /// Collection of wave files that can be played for this response.
        /// Assume any can be picked at random? Or should we divide by RelationshipStrength?
        /// </summary>
        public List<ResponseFile> ResponseFileList { get; set; }

        public string Id { get; set; }

    }
}
