using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationsCore.Interfaces
{
    /// <summary>
    /// Need to ensure that all objects have an Id for uniqueness. Id is used to search and load, and save
    /// </summary>
    public interface IRepositoryObject
    {
        string Id { get; set; }
    }
}
