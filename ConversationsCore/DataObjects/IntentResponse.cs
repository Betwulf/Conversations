using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConversationsCore.Interfaces;
using System.Threading.Tasks;
using System.ComponentModel;
using ConversationsCore.Helpers;

namespace ConversationsCore.DataObjects
{
    public class IntentResponse
    {
        /// <summary>
        /// This should be unique within a character, no other use
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// This must match the intent of the speaker
        /// </summary>
        public string Intent { get; set; }

        /// <summary>
        /// Relationship strength has to be at least equal to this value to match
        /// </summary>
        public int RelationshipStrength { get; set; }

        /// <summary>
        /// Must match context flags in character
        /// </summary>
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
        "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
       typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(CsvConverter))]
        public List<string> ContextNeeded { get; set; }

        /// <summary>
        /// If used, this response will add these context flags to the character
        /// </summary>
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
        "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
       typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(CsvConverter))]
        public List<string> ContextToBeAdded { get; set; }

        /// <summary>
        /// If this is true, then only need to match on one entity value
        /// </summary>
        public bool EntityValueNeedsOnlyOneMatch { get; set; }

        /// <summary>
        /// Must match any value or values 
        /// </summary>
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
        "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
       typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(CsvConverter))]
        public List<string> EntityValues { get; set; }

        /// <summary>
        /// Collection of wave files that can be played for this response.
        /// Assume any can be picked at random?
        /// </summary>

        public IntentResponse()
        {
            ContextNeeded = new List<string>();
            ContextToBeAdded = new List<string>();
            EntityValues = new List<string>();
        }

        public override string ToString()
        {
            return Id;
        }

    }
}
