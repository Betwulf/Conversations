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
        public int RelationshipStrengthNeeded { get; set; }

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
        /// This value will improve or weaken the relationship value of the character if this response is selected
        /// </summary>
        public int RelationshipStrengthToBeAltered { get; set; }

        /// <summary>
        /// If blank then stay on current state, otherwise, change the Character's CurrentState
        /// </summary>
        public string StateToBeSetNext { get; set; }


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
        /// The written version of what the audio response should say. Audio may contain several variations.
        /// </summary>
        public string ResponseText { get; set; }



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

        /// <summary>
        /// Collection of wave files that can be played for this response exist by convention in a directory 
        /// Uniquely pathed to this instance. Assume any can be picked at random.
        /// </summary>
        public string GetResponseDirectory(Repository.ConversationsRepository Rep, Character aChar, State currState)
        {
            return $"{Rep.CharacterDB.ClassDirectory}\\{aChar.Id}\\{currState.Id}\\{Id}";
        }

    }
}
